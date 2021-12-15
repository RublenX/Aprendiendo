using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionObjetosNoEntidad
{
    public class Registro
    {
        public int RegistroId { get; set; }

        public string Nombre { get; set; }

        public Guid Identificador { get; set; }

        public int Capacidad { get; set; }

        public bool Habilitado { get; set; }
    }
}
