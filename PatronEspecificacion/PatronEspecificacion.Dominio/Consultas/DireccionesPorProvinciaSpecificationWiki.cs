using PatronEspecificacion.Dominio.Consultas.PatronWiki;
using PatronEspecificacion.Dominio.Entidades;
using System;
using System.Linq.Expressions;

namespace PatronEspecificacion.Dominio.Consultas
{
    public class DireccionesPorProvinciaSpecificationWiki : LinqSpecification<DireccionEspanolaEntity>
    {
        private readonly string provincia;

        public DireccionesPorProvinciaSpecificationWiki(string provincia)
        {
            this.provincia = provincia;
        }

        public override Expression<Func<DireccionEspanolaEntity, bool>> AsExpression()
        {
            return (x) => x.Provincia == this.provincia;
        }
    }
}
