using ArpLookup;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Text;


/*
 * El código viene de Copilot:
 * Desde un proyecto en .NET8 con C# ¿se puede crear código que recopile las direcciones IP conectadas a la misma red y sus correspondientes MAC?
 * ¿Y no hay algún paquete u otra forma que permita hacerlo de una forma más nativa?
 * El primer ejemplo que me has puesto no funciona bien porque la expresión regular no es la correcta. Te pongo la salida de la consola y me lo corriges:
 * Interfaz: 192.168.1.6 --- 0x5
  Dirección de Internet          Dirección física      Tipo
  192.168.1.1           e4-ab-89-92-2e-01     dinámico  
  192.168.1.2           58-d5-6e-92-60-b6     dinámico
 * Busco una forma algo más nativa o que use un código de más bajo nivel para saber las IPs que están conectadas a mi red ¿hay alguna forma más?
 * Me da que utilizando hilos hay una forma más eficiente de usar la clase Ping
 * Añademe el código necesario para obtener las MAC de las direcciones IP que obtenga
 * ¿Hay forma de saber el nombre del dispositivo?
 * Y existe alguna forma de hacerlo de tal forma que funcione en Windows y Linux?
 */
namespace ConsoleARP
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.WriteLine("\r\nMétodo ARP de Windows");

                // Ejecutar el comando arp -a
                Process process = new Process();
                process.StartInfo.FileName = "arp";
                process.StartInfo.Arguments = "-a";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();

                // Leer la salida del comando
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                // Expresión regular para extraer las direcciones IP y MAC
                //Regex regex = new Regex(@"(\d+\.\d+\.\d+\.\d+)\s+([\da-fA-F]{2}(:[\da-fA-F]{2}){5})");
                Regex regex = new Regex(@"(\d+\.\d+\.\d+\.\d+)\s+([a-fA-F0-9-]{17})\s+\w+");
                var matches = regex.Matches(output);

                // Mostrar las direcciones IP y MAC
                foreach (Match match in matches)
                {
                    Console.WriteLine($"IP: {match.Groups[1].Value}, MAC: {match.Groups[2].Value}");
                } 
            }

            /* Mediante el paquete ArpLookup - En Linux necesita paquetes extra : net-tools */
            Console.WriteLine("\r\nMétodo con ArpLookup:");

            IPAddress ipAddressArp = IPAddress.Parse("192.168.1.1");
            PhysicalAddress macAddress = Arp.Lookup(ipAddressArp);

            Console.WriteLine($"IP: {ipAddressArp}, MAC: {macAddress}");

            /* Algo más nativo */
            Console.WriteLine("\r\nMétodo con NetworkInterface (Windows y Linux):");

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus == OperationalStatus.Up)
                {
                    IPInterfaceProperties properties = ni.GetIPProperties();
                    foreach (UnicastIPAddressInformation ip in properties.UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            Console.WriteLine($"IP Address: {ip.Address}");
                        }
                    }
                }
            }


            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.WriteLine("\r\nMétodo PING a un rango de IPs:");
                string baseIP = "192.168.1.";

                Parallel.For(1, 255, i =>
                    {
                        string ip = baseIP + i;
                        Ping ping = new Ping();
                        PingReply reply = ping.Send(ip, 100);

                        if (reply.Status == IPStatus.Success)
                        {
                            var salidaIpMac = $"Active IP: {ip}";
                            //Console.WriteLine($"Active IP: {ip}");
                            string macAddress = GetMacAddress(ip);
                            if (!string.IsNullOrEmpty(macAddress))
                            {
                                salidaIpMac += $" - MAC Address: {macAddress}";
                            }

                            string hostName = GetHostName(ip);
                            if (!string.IsNullOrEmpty(hostName))
                            {
                                Console.WriteLine($"{salidaIpMac} - Host Name: {hostName}");
                            }
                        }
                    }); 
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Console.WriteLine("\r\nMétodo ARP Linux para una IP concreta:");

                var ipAddress = "192.168.1.1";
                // Implementación para Linux
                try
                {
                    var process = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = "/bin/bash",
                            Arguments = $"-c \"arp -n {ipAddress} | grep {ipAddress} | awk '{{print $3}}'\"",
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        }
                    };
                    process.Start();
                    string result = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                    Console.WriteLine(result.Trim());
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"ERROR con Linux: {ex.GetType().ToString()}  - {ex.Message}");
                }
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Console.WriteLine("\r\nForma de hacer para Linux");

                string baseIP = "192.168.1.";
                List<Task> tasks = new List<Task>();

                for (int i = 1; i < 255; i++)
                {
                    string ip = baseIP + i;
                    tasks.Add(Task.Run(() => PingAndFetchMacLinux(ip)));
                }

                await Task.WhenAll(tasks);
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Console.WriteLine("\r\nForma de hacer para Linux con ArpLookup");

                string baseIP = "192.168.1.";
                List<Task> tasks = new List<Task>();

                for (int i = 1; i < 255; i++)
                {
                    string ip = baseIP + i;
                    tasks.Add(Task.Run(() => CheckIpAndFetchMac(ip)));
                }

                await Task.WhenAll(tasks);
            }
        }

        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        private static extern int SendARP(int destIp, int srcIp, byte[] macAddr, ref int phyAddrLen);

        [DllImport("ws2_32.dll")]
        private static extern int inet_addr(string cp);

        private static string GetMacAddress(string ipAddress)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                int destIp = inet_addr(ipAddress);
                byte[] macAddr = new byte[6];
                int macAddrLen = macAddr.Length;

                if (SendARP(destIp, 0, macAddr, ref macAddrLen) != 0)
                {
                    return null;
                }

                string[] str = new string[macAddrLen];
                for (int i = 0; i < macAddrLen; i++)
                {
                    str[i] = macAddr[i].ToString("x2");
                }

                return string.Join(":", str);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                // Implementación para Linux
                try
                {
                    var process = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = "/bin/bash",
                            Arguments = $"-c \"arp -n {ipAddress} | grep {ipAddress} | awk '{{print $3}}'\"",
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        }
                    };
                    process.Start();
                    string result = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                    return result.Trim();
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }

        private static string GetHostName(string ipAddress)
        {
            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(ipAddress);
                return hostEntry.HostName;
            }
            catch (Exception)
            {
                return "DESCONOCIDO";
            }
        }

        private static async Task PingAndFetchMacLinux(string ipAddress)
        {
            Ping ping = new Ping();
            PingReply reply = await ping.SendPingAsync(ipAddress, 100);

            if (reply.Status == IPStatus.Success)
            {
                var salida = $"Active IP: {ipAddress} - MAC Address: ";
                string macAddress = GetMacAddressLinux(ipAddress);
                if (!string.IsNullOrEmpty(macAddress))
                {
                    salida += macAddress;
                }
                Console.WriteLine(salida);
            }
        }

        private static string GetMacAddressLinux(string ipAddress)
        {
            try
            {
                string[] lines = File.ReadAllLines("/proc/net/arp");
                var strBld = new StringBuilder();
                foreach (string line in lines)
                {
                    strBld.AppendLine(line);
                    string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length >= 4 && parts[0] == ipAddress)
                    {
                        return parts[3];
                    }
                }
                var parada = strBld.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading ARP cache: {ex.Message}");
            }
            return null;
        }

        private static async Task CheckIpAndFetchMac(string ipAddress)
        {
            if (await IsHostAlive(ipAddress))
            {
                var salida = $"Active IP: {ipAddress} - MAC Address: ";
                PhysicalAddress macAddress = await Arp.LookupAsync(IPAddress.Parse(ipAddress));
                if (macAddress != null)
                {
                    salida += macAddress;
                }
                Console.WriteLine(salida);
            }
        }

        private static async Task<bool> IsHostAlive(string ipAddress)
        {
            try
            {
                using (var ping = new Ping())
                {
                    var reply = await ping.SendPingAsync(ipAddress, 100);
                    return reply.Status == IPStatus.Success;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
