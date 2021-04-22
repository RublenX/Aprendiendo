using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace GestorGenealogico.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Logger que muestra mensajes en la ventana de depuración de Visual Studio hasta que se carga el logger de la configuración
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Debug()
                .CreateBootstrapLogger();

            try
            {
                Log.Information("***********************Iniciando el alojamiento web***********************");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "########################Servicio detenido de forma inesperada########################");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                // Se eliminan loggers prerregistrados
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                })
                // Se incluye Serilog como logger mediante la configuración desde Microsoft.Extensions.Configuration
                .UseSerilog((HostBuilderContext context, LoggerConfiguration loggerConfiguration) =>
                {
                    loggerConfiguration.ReadFrom.Configuration(context.Configuration);

                    // Otra forma de configuarlo sin fichero de configuración
                    //loggerConfiguration.WriteTo.File(
                    //    "trazasPorCodigo.log",
                    //    Serilog.Events.LogEventLevel.Warning,
                    //    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [Equipo:{MachineName}] [Hilo:{ThreadId}] [Correlación:{CorrelationId}] {Message:lj}{NewLine}{Exception}",
                    //    rollingInterval: RollingInterval.Day,
                    //    retainedFileCountLimit: 3)
                    //.Enrich.WithThreadId()
                    //.Enrich.WithCorrelationId()
                    //.Enrich.WithMachineName();
                });
    }
}
