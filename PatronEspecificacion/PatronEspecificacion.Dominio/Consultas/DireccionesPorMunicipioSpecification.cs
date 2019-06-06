using PatronEspecificacion.Dominio.Consultas.PatronDdd;
using PatronEspecificacion.Dominio.Entidades;
using System;
using System.Linq.Expressions;

namespace PatronEspecificacion.Dominio.Consultas
{
    public class DireccionesPorMunicipioSpecification : Specification<DireccionEspanolaEntity>
    {
        private readonly string municipio;

        public DireccionesPorMunicipioSpecification(string municipio) : base()
        {
            this.municipio = municipio;
        }

        public override Expression<Func<DireccionEspanolaEntity, bool>> SatisfiedBy()
        {
            return (x) => x.Municipio == this.municipio;
        }

        // De la implementación de la Wikipedia
        //public override Expression<Func<DireccionEspanolaEntity, bool>> AsExpression()
        //{
        //    return (x) => x.Municipio == this.municipio;
        //}

        // De la implementación básica
        //public override Expression<Func<DireccionEspanolaEntity, bool>> IsSatisfiedBy()
        //{
        //    return (x) => x.Municipio == this.municipio;
        //}
    }
}
