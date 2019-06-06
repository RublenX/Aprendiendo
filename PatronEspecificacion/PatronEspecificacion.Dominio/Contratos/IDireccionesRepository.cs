using PatronEspecificacion.Dominio.Consultas.PatronDdd;
using PatronEspecificacion.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PatronEspecificacion.Dominio.Contratos
{
    public interface IDireccionesRepository
    {
        string CualquierValor { get; set; }

        ICollection<string> DameValoresPrueba(int cantidad);

        ICollection<DireccionEspanolaEntity> GetDirecciones();
        ICollection<DireccionEspanolaEntity> GetDirecciones(ISpecification<DireccionEspanolaEntity> especificacion);
        ICollection<DireccionEspanolaEntity> GetDirecciones(Expression<Func<DireccionEspanolaEntity, bool>> exp);
    }
}
