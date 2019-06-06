using System;
using System.Linq.Expressions;

namespace PatronEspecificacion.Dominio.Consultas.PatronBasico
{
    public abstract class Specification<TEntity> : ISpecification<TEntity>
    {
        public abstract Expression<Func<TEntity, bool>> IsSatisfiedBy();
    }
}
