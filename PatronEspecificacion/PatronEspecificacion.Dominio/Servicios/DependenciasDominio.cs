using Microsoft.Extensions.DependencyInjection;
using PatronEspecificacion.InfraestructuraDatos.Contratos;
using PatronEspecificacion.InfraestructuraDatos.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatronEspecificacion.Dominio.Servicios
{
    public static class DependenciasDominio
    {
        public static IServiceCollection AgregarDependenciasDominio(this IServiceCollection services)
        {
            services.AddSingleton<IDireccionesRepository, DireccionesRepository>();

            return services;
        }
    }
}
