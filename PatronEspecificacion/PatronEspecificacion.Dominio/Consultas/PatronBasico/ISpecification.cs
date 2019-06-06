using System;
using System.Linq.Expressions;

namespace PatronEspecificacion.Dominio.Consultas.PatronBasico
{
    public interface ISpecification<TEntity>
    {
        Expression<Func<TEntity, bool>> IsSatisfiedBy();
    }
}
