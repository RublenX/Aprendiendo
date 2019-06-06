using PatronEspecificacion.Dominio.Consultas.PatronBasico;
using PatronEspecificacion.Dominio.Entidades;
using System;
using System.Linq.Expressions;

namespace PatronEspecificacion.Dominio.Consultas
{
    public class DireccionesPorMunicipioSpecificationBasico : Specification<DireccionEspanolaEntity>
    {
        private readonly string municipio;

        public DireccionesPorMunicipioSpecificationBasico(string municipio) : base()
        {
            this.municipio = municipio;
        }

        public override Expression<Func<DireccionEspanolaEntity, bool>> IsSatisfiedBy()
        {
            return (x) => x.Municipio == this.municipio;
        }
    }
}
