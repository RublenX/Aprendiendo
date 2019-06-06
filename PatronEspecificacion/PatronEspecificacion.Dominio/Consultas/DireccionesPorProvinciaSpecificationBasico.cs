using PatronEspecificacion.Dominio.Consultas.PatronBasico;
using PatronEspecificacion.Dominio.Entidades;
using System;
using System.Linq.Expressions;

namespace PatronEspecificacion.Dominio.Consultas
{
    public class DireccionesPorProvinciaSpecificationBasico : Specification<DireccionEspanolaEntity>
    {
        private readonly string provincia;

        public DireccionesPorProvinciaSpecificationBasico(string provincia) : base()
        {
            this.provincia = provincia;
        }

        public override Expression<Func<DireccionEspanolaEntity, bool>> IsSatisfiedBy()
        {
            return (x) => x.Provincia == this.provincia;
        }
    }
}
