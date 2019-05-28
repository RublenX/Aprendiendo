using Microsoft.Extensions.DependencyInjection;
using PatronEspecificacion.Dominio.Servicios;
using PatronEspecificacion.Dominio.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatronEspecificacion.WebApi.Servicios
{
    public static class Dependencias
    {
        public static IServiceCollection AgregarDependencias(this IServiceCollection services)
        {
            // Se instancia una única vez mediante Singleton
            services.AddSingleton<IGestorDirecciones, GestorDirecciones>();

            return services;
        }
    }
}
