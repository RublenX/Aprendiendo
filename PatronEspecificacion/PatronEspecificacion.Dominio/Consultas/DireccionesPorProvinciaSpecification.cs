using PatronEspecificacion.Dominio.Consultas.PatronDdd;
using PatronEspecificacion.Dominio.Entidades;
using System;
using System.Linq.Expressions;

namespace PatronEspecificacion.Dominio.Consultas
{
    public class DireccionesPorProvinciaSpecification : Specification<DireccionEspanolaEntity>
    {
        private readonly string provincia;

        public DireccionesPorProvinciaSpecification(string provincia)
        {
            this.provincia = provincia;
        }

        public override Expression<Func<DireccionEspanolaEntity, bool>> SatisfiedBy()
        {
            return (x) => x.Provincia == this.provincia;
        }

        // De la implementación de la Wikipedia
        //public override Expression<Func<DireccionEspanolaEntity, bool>> AsExpression()
        //{
        //    return (x) => x.Provincia == this.provincia;
        //}

        // De la implementación básica
        //public override Expression<Func<DireccionEspanolaEntity, bool>> IsSatisfiedBy()
        //{
        //    return (x) => x.Provincia == this.provincia;
        //}
    }
}
