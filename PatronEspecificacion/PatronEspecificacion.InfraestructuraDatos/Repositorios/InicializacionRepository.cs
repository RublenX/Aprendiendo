using PatronEspecificacion.Dominio.Contratos;
using PatronEspecificacion.InfraestructuraDatos.Persistencia;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatronEspecificacion.InfraestructuraDatos.Repositorios
{
    public class InicializacionRepository : IInicializacionRepository
    {
        public void InicializarBbdd()
        {
            using (PoCEspecificacionContext ctx = new PoCEspecificacionContext())
            {
                DbInitializer.Initialize(ctx);
            }
        }
    }
}
