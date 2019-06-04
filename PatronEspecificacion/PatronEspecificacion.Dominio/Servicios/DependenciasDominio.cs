using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using PatronEspecificacion.Dominio.Servicios.IoC;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace PatronEspecificacion.Dominio.Servicios
{
    /// <summary>
    /// Inyección de dependencias del proyecto de Dominio
    /// </summary>
    public static class DependenciasDominio
    {
        /// <summary>
        /// Método de extensión que realiza la inyección de dependencias del proyecto de Dominio
        /// </summary>
        /// <param name="services">Collección de servicios para usar la inyección de dependencias</param>
        /// <returns>Collección de servicios</returns>
        public static IServiceCollection AgregarDependenciasDominio(this IServiceCollection services)
        {
            var localPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var ficheroConfiguracionDependencias = Path.Combine(localPath, "ConfiguracionDependencias.json");

            // Comprueba la existencia del fichero
            if (File.Exists(ficheroConfiguracionDependencias))
            {
                string strConfiguracionDependencias = File.ReadAllText(ficheroConfiguracionDependencias);
                // Comprueba que no viene vacío
                if (!string.IsNullOrWhiteSpace(strConfiguracionDependencias))
                {
                    var configuracionDependencias = JsonConvert.DeserializeObject<List<ConfiguracionDependencia>>(strConfiguracionDependencias);
                    // Comprueba que tiene configuraciones
                    if (configuracionDependencias != null && configuracionDependencias.Any())
                    {
                        foreach (var configuracionDependencia in configuracionDependencias)
                        {
                            Type tipoContrato = Type.GetType(configuracionDependencia.ContratoEspacioNombres);
                            // Comprueba que el tipo del contrato está bien definido
                            if (tipoContrato != null)
                            {
                                Type tipoDependencia = null;

                                // Comprueba si la ruta de la dll es absoluta o relativa
                                if (File.Exists(configuracionDependencia.ImplementadorRutaEnsamblado))
                                {
                                    // Ruta absoluta
                                    tipoDependencia = GestorDependencias.ObtenerTipoDependencia(tipoContrato, configuracionDependencia.ImplementadorRutaEnsamblado, configuracionDependencia.ImplementadorEspacioNombresClase);
                                }
                                else if (File.Exists(Path.Combine(localPath, configuracionDependencia.ImplementadorRutaEnsamblado)))
                                {
                                    // Ruta relativa
                                    tipoDependencia = GestorDependencias.ObtenerTipoDependencia(tipoContrato, Path.Combine(localPath, configuracionDependencia.ImplementadorRutaEnsamblado), configuracionDependencia.ImplementadorEspacioNombresClase);
                                }

                                // Si encuentra el tipo de dependencia lo añade
                                if (tipoDependencia != null)
                                {
                                    // Por defecto es Singleton
                                    switch (configuracionDependencia.TipoRegistro)
                                    {
                                        case OpcionRegistro.Scope:
                                            services.AddScoped(tipoContrato, tipoDependencia);
                                            break;
                                        case OpcionRegistro.Transient:
                                            services.AddTransient(tipoContrato, tipoDependencia);
                                            break;
                                        default:
                                            services.AddSingleton(tipoContrato, tipoDependencia);
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return services;
        }
    }
}
