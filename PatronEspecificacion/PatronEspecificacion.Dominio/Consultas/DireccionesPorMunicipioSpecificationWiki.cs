using PatronEspecificacion.Dominio.Consultas.PatronWiki;
using PatronEspecificacion.Dominio.Entidades;
using System;
using System.Linq.Expressions;

namespace PatronEspecificacion.Dominio.Consultas
{
    public class DireccionesPorMunicipioSpecificationWiki : LinqSpecification<DireccionEspanolaEntity>
    {
        private readonly string municipio;

        public DireccionesPorMunicipioSpecificationWiki(string municipio)
        {
            this.municipio = municipio;
        }

        public override Expression<Func<DireccionEspanolaEntity, bool>> AsExpression()
        {
            return (x) => x.Municipio == this.municipio;
        }
    }
}
