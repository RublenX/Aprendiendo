using PatronEspecificacion.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatronEspecificacion.Dominio.Contratos
{
    public interface IDireccionesRepository
    {
        string CualquierValor { get; set; }

        ICollection<string> DameValoresPrueba(int cantidad);

        ICollection<DireccionEspanolaEntity> GetDirecciones();
    }
}
