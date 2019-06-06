using PatronEspecificacion.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PatronEspecificacion.Dominio.Contratos
{
    public interface IDireccionesRepository
    {
        ICollection<DireccionEspanolaEntity> GetDirecciones();
        ICollection<DireccionEspanolaEntity> GetDirecciones(Expression<Func<DireccionEspanolaEntity, bool>> exp);
        ICollection<DireccionEspanolaEntity> GetDireccionesBasico(Consultas.PatronBasico.ISpecification<DireccionEspanolaEntity> especificacion);
        ICollection<DireccionEspanolaEntity> GetDireccionesWiki(Consultas.PatronWiki.ISpecification<DireccionEspanolaEntity> especificacion);
        ICollection<DireccionEspanolaEntity> GetDireccionesDdd(Consultas.PatronDdd.ISpecification<DireccionEspanolaEntity> especificacion);
    }
}
