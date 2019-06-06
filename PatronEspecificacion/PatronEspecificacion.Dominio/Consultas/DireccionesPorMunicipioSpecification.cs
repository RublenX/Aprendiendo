using PatronEspecificacion.Dominio.Consultas.PatronBasico;
using PatronEspecificacion.Dominio.Entidades;
using System;
using System.Linq.Expressions;

namespace PatronEspecificacion.Dominio.Consultas
{
    public class DireccionesPorMunicipioSpecification : Specification<DireccionEspanolaEntity>
    {
        private readonly string municipio;

        public DireccionesPorMunicipioSpecification(string municipio)
        {
            this.municipio = municipio;
        }

        public override Expression<Func<DireccionEspanolaEntity, bool>> IsSatisfiedBy()
        {
            return (x) => x.Municipio == this.municipio;
        }
    }
}
