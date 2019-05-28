using PatronEspecificacion.Dominio.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatronEspecificacion.Dominio.Entidades
{
    public class DireccionEspanolaEntity : EntidadBase
    {
        public int Id { get; set; }

        public string Provincia { get; set; }

        public string Municipio { get; set; }

        public string Calle { get; set; }
    }
}
