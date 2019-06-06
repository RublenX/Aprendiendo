using PatronEspecificacion.Dominio.Consultas.PatronWiki;
using PatronEspecificacion.Dominio.Entidades;
using System;
using System.Linq.Expressions;

namespace PatronEspecificacion.Dominio.Consultas
{
    public class DireccionesPorProvinciaSpecification : LinqSpecification<DireccionEspanolaEntity>
    {
        private readonly string provincia;

        public DireccionesPorProvinciaSpecification(string provincia)
        {
            this.provincia = provincia;
        }

        public override Expression<Func<DireccionEspanolaEntity, bool>> AsExpression()
        {
            return (x) => x.Provincia == this.provincia;
        }

        // De la implementación básica
        //public override Expression<Func<DireccionEspanolaEntity, bool>> IsSatisfiedBy()
        //{
        //    return (x) => x.Provincia == this.provincia;
        //}
    }
}
