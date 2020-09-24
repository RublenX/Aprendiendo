using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFEjemplo.Models
{
    public class Autor
    {
        public int AutorId { get; set; }

        public string Nombre { get; set; }

        public List<Cancion> Canciones { get; set; }
    }
}
