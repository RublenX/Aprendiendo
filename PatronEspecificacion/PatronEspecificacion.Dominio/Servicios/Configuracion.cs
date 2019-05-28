using PatronEspecificacion.InfraestructuraDatos.Persistencia;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatronEspecificacion.Dominio.Servicios
{
    public static class Configuracion
    {
        public static void InicializarBbdd()
        {
            DbInitializer.Initialize(null);
        }
    }
}
