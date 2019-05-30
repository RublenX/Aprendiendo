using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PatronEspecificacion.Dominio.Contratos;
using PatronEspecificacion.Dominio.Entidades;
using PatronEspecificacion.Dominio.Servicios.IoC;
using System.IO;
using System.Reflection;

namespace PatronEspecificacion.Dominio.Servicios
{
    public static class DependenciasDominio
    {
        public static IServiceCollection AgregarDependenciasDominio(this IServiceCollection services)
        {
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            Type tipo = GestorDependencias.ObtenerTipoDependencia(Path.Combine(path, "PatronEspecificacion.InfraestructuraDatos.dll"), "PatronEspecificacion.InfraestructuraDatos.Repositorios.DireccionesRepository");
            services.AddSingleton(typeof(IDireccionesRepository), tipo);

            tipo = GestorDependencias.ObtenerTipoDependencia(Path.Combine(path, "PatronEspecificacion.InfraestructuraDatos.dll"), "PatronEspecificacion.InfraestructuraDatos.Repositorios.InicializacionRepository");
            services.AddSingleton(typeof(IInicializacionRepository), tipo);

            return services;
        }
    }
}
