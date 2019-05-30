using Microsoft.Extensions.DependencyInjection;
using PatronEspecificacion.Dominio.Contratos;
using System;

namespace PatronEspecificacion.Dominio.Servicios
{
    public static class Configuracion
    {
        public static void InicializarBbdd(IServiceProvider serviceProvider)
        {
            // Resuelve la inicialización de forma manual
            var inicializacionRepo = serviceProvider.GetService<IInicializacionRepository>();
            inicializacionRepo.InicializarBbdd();
        }
    }
}
