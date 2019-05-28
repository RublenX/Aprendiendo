using PatronEspecificacion.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatronEspecificacion.Dominio.Servicios.Interfaces
{
    public interface IGestorDirecciones
    {
        ICollection<DireccionEspanolaEntity> ObtenerDirecciones();
    }
}
