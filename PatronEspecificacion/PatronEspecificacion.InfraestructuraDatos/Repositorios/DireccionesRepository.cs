using PatronEspecificacion.InfraestructuraDatos.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using PatronEspecificacion.Dominio.Contratos;
using PatronEspecificacion.Dominio.Entidades;
using System.Linq.Expressions;
using PatronEspecificacion.InfraestructuraDatos.Base;

namespace PatronEspecificacion.InfraestructuraDatos.Repositorios
{
    public class DireccionesRepository : IDireccionesRepository
    {
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
                    .Where(exp);
                string parada = query.ToSql();
                salida = query.ToList();
            }

            return salida;
        }

        public ICollection<DireccionEspanolaEntity> GetDireccionesBasico(Dominio.Consultas.PatronBasico.ISpecification<DireccionEspanolaEntity> especificacion)
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
                .Where(especificacion.IsSatisfiedBy());
                string parada = query.ToSql();
                salida = query.ToList();
            }

            return salida;
        }

        public ICollection<DireccionEspanolaEntity> GetDireccionesWiki(Dominio.Consultas.PatronWiki.ISpecification<DireccionEspanolaEntity> especificacion)
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
                .Where(d => especificacion.IsSatisfiedBy(d));
                string parada = query.ToSql();
                salida = query.ToList();
            }

            return salida;
        }

        public ICollection<DireccionEspanolaEntity> GetDireccionesDdd(Dominio.Consultas.PatronDdd.ISpecification<DireccionEspanolaEntity> especificacion)
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
    }
}
