using PatronEspecificacion.InfraestructuraDatos.Contratos;
using PatronEspecificacion.InfraestructuraDatos.Modelos;
using PatronEspecificacion.InfraestructuraDatos.Persistencia;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PatronEspecificacion.InfraestructuraDatos.Repositorios
{
    public class DireccionesRepository : IDireccionesRepository
    {
        public string CualquierValor { get; set; } = "Esta propiedad contiene texto";

        public ICollection<string> DameValoresPrueba(int cantidad)
        {
            List<string> salida = new List<string>();
            Random rdn = new Random();

            for (int i = 0; i < cantidad; i++)
            {
                salida.Add(rdn.Next(0, 10000).ToString());
            }

            return salida;
        }

        public ICollection<Direccion> GetDirecciones()
        {
            ICollection<Direccion> salida;

            using (PoCEspecificacionContext ctx = new PoCEspecificacionContext())
            {
                salida = ctx.Direcciones.ToList();
            }

            return salida;
        }
    }
}
