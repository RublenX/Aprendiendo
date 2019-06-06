using PatronEspecificacion.InfraestructuraDatos.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using PatronEspecificacion.Dominio.Contratos;
using PatronEspecificacion.Dominio.Entidades;
using System.Linq.Expressions;
using PatronEspecificacion.InfraestructuraDatos.Base;
using PatronEspecificacion.Dominio.Consultas.PatronDdd;

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

        public ICollection<DireccionEspanolaEntity> GetDirecciones(ISpecification<DireccionEspanolaEntity> especificacion)
        {
            ICollection<DireccionEspanolaEntity> salida;

            using (PoCEspecificacionContext ctx = new PoCEspecificacionContext())
            {
                IQueryable<DireccionEspanolaEntity> query = ctx.Direcciones.Select(d => new DireccionEspanolaEntity
                {
                    Id = d.DireccionId,
                    Provincia = d.Provincia,
                    Municipio = d.Municipio,
                    Calle = d.Calle
                })
                .Where(especificacion.SatisfiedBy());
                string parada = query.ToSql();
                salida = query.ToList();
            }

            return salida;
        }

        public ICollection<DireccionEspanolaEntity> GetDirecciones(Expression<Func<DireccionEspanolaEntity, bool>> exp)
        {
            ICollection<DireccionEspanolaEntity> salida;

            using (PoCEspecificacionContext ctx = new PoCEspecificacionContext())
            {
                IQueryable<DireccionEspanolaEntity> query = ctx.Direcciones
                    .Select(d => new DireccionEspanolaEntity
                    {
                        Id = d.DireccionId,
                        Provincia = d.Provincia,
                        Municipio = d.Municipio,
                        Calle = d.Calle
                    })
                    .Where(d => exp.Compile()(d));
                string parada = query.ToSql();
                salida = query.ToList();
            }

            return salida;
        }
    }
}
