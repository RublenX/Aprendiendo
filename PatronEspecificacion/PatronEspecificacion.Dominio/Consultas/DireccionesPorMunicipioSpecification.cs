using PatronEspecificacion.Dominio.Consultas.PatronWiki;
using PatronEspecificacion.Dominio.Entidades;
using System;
using System.Linq.Expressions;

namespace PatronEspecificacion.Dominio.Consultas
{
    public class DireccionesPorMunicipioSpecification : LinqSpecification<DireccionEspanolaEntity>
    {
        private readonly string municipio;

        public DireccionesPorMunicipioSpecification(string municipio)
        {
            this.municipio = municipio;
        }

        public override Expression<Func<DireccionEspanolaEntity, bool>> AsExpression()
        {
            return (x) => x.Municipio == this.municipio;
        }

        // De la implementación básica
        //public override Expression<Func<DireccionEspanolaEntity, bool>> IsSatisfiedBy()
        //{
        //    return (x) => x.Municipio == this.municipio;
        //}
    }
}
