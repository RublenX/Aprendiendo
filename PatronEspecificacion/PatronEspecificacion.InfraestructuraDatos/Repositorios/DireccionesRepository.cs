//using PatronEspecificacion.InfraestructuraDatos.Contratos;
using PatronEspecificacion.InfraestructuraDatos.Modelos;
using PatronEspecificacion.InfraestructuraDatos.Persistencia;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PatronEspecificacion.Dominio.Contratos;
using PatronEspecificacion.Dominio.Entidades;

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

        public ICollection<DireccionEspanolaEntity> GetDirecciones()
        {
            ICollection<DireccionEspanolaEntity> salida;

            using (PoCEspecificacionContext ctx = new PoCEspecificacionContext())
            {
                salida = ctx.Direcciones.Select(d => new DireccionEspanolaEntity
                {
                    Id = d.DireccionId,
                    Provincia = d.Provincia,
                    Municipio = d.Municipio,
                    Calle = d.Calle
                }).ToList();
            }

            return salida;
        }
    }
}
