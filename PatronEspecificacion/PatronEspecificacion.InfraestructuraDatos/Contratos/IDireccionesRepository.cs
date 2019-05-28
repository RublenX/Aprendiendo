using PatronEspecificacion.InfraestructuraDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatronEspecificacion.InfraestructuraDatos.Contratos
{
    public interface IDireccionesRepository
    {
        string CualquierValor { get; set; }

        ICollection<string> DameValoresPrueba(int cantidad);

        ICollection<Direccion> GetDirecciones();
    }
}
