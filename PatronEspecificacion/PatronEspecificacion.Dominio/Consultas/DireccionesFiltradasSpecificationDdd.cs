using PatronEspecificacion.Dominio.Consultas.PatronDdd;
using PatronEspecificacion.Dominio.Entidades;
using System;
using System.Linq.Expressions;

namespace PatronEspecificacion.Dominio.Consultas
{
    public class DireccionesFiltradasSpecificationDdd : Specification<DireccionEspanolaEntity>
    {
        private readonly DireccionEspanolaFiltro filtro;

        public DireccionesFiltradasSpecificationDdd(DireccionEspanolaFiltro filtro)
        {
            this.filtro = filtro;
        }

        public override Expression<Func<DireccionEspanolaEntity, bool>> SatisfiedBy()
        {
            Specification<DireccionEspanolaEntity> spec = new TrueSpecification<DireccionEspanolaEntity>();

            if (!string.IsNullOrWhiteSpace(filtro.Provincia))
            {
                spec &= new DirectSpecification<DireccionEspanolaEntity>(d => d.Provincia == (filtro.Provincia));
            }
            if (!string.IsNullOrWhiteSpace(filtro.Municipio))
            {
                spec &= new DirectSpecification<DireccionEspanolaEntity>(d => d.Municipio == (filtro.Provincia));
            }
            if (filtro.Exclusion != null)
            {
                spec &= new NotSpecification<DireccionEspanolaEntity>(new DireccionesFiltradasSpecificationDdd(filtro.Exclusion));
            }

            return spec.SatisfiedBy();
        }
    }
}
