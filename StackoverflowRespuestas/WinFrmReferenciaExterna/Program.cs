using System;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFrmReferenciaExterna
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CargarLibreriasExternas();
            //new LinQAgrupados().Lanzar();
            string csv = "1,Locard,rlocard0@php.net,Female,S,$90.80\r\n" +
                            "2,Iacobassi,siacobassi1 @timesonline.co.uk,Male,XL,$12.73\r\n" +
                            "3,Schall,dschall2 @dagondesign.com,Male,XL,$17.84\r\n" +
                            "4,Grinyov,ggrinyov3 @sphinn.com,Female,XL,$13.57\r\n" +
                            "5,Bewley,bbewley4 @cbsnews.com,Male,S,$10.20";
            new LinQAgrupados().GananciaValor(csv.Split(new[] { Environment.NewLine }, StringSplitOptions.None));
            Application.Run(new Form1());
        }

        public static Assembly DllExterna { get; set; }

        private static void CargarLibreriasExternas()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);
        }

        private static Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            //This handler is called only when the common language runtime tries to bind to the assembly and fails.

            //Retrieve the list of referenced assemblies in an array of AssemblyName.
            Assembly MyAssembly, objExecutingAssemblies;
            string strTempAssmbPath = "";

            objExecutingAssemblies = Assembly.GetExecutingAssembly();
            AssemblyName[] arrReferencedAssmbNames = objExecutingAssemblies.GetReferencedAssemblies();

            //Loop through the array of referenced assembly names.
            foreach (AssemblyName strAssmbName in arrReferencedAssmbNames)
            {
                //Check for the assembly names that have raised the "AssemblyResolve" event.
                if (strAssmbName.FullName.Substring(0, strAssmbName.FullName.IndexOf(",")) == args.Name.Substring(0, args.Name.IndexOf(",")))
                {
                    //Build the path of the assembly from where it has to be loaded.
                    strTempAssmbPath = @"D:\JuanRu\GitHub\Aprendiendo\StackoverflowRespuestas\ReferenciaDll.UnaLibCualquiera\bin\Debug\ReferenciaDll.UnaLibCualquiera.dll";
                    break;
                }

            }
            //Load the assembly from the specified path. 
            MyAssembly = Assembly.LoadFrom(strTempAssmbPath);

            //Return the loaded assembly.
            return MyAssembly;
        }
    }
}
