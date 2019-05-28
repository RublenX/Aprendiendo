using System;
using System.Collections.Generic;
using System.Text;

namespace PatronEspecificacion.InfraestructuraDatos.Modelos
{
    public class Direccion
    {
        public int DireccionId { get; set; }

        public string Pais { get; set; }

        public string ComunidadAutonoma { get; set; }

        public string Provincia { get; set; }

        public string Municipio { get; set; }

        public string Calle { get; set; }
    }
}
