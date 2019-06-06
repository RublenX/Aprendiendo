using PatronEspecificacion.Dominio.Consultas;
using PatronEspecificacion.Dominio.Consultas.PatronBasico;
using PatronEspecificacion.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

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
