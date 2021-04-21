using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.Handlers.Ovejas.Command;

namespace WebApiCore.Datos
{
    /// <summary>
    /// OJO no preparada para ejecucione concurrentes es sólo para tener datos
    /// </summary>
    public static class OvejasService
    {
        private static List<OvejaSummary> Ovejas { get; set; }

        public static List<OvejaSummary> DameOvejas()
        {
            if (Ovejas == null)
            {
                string nombre = "Oveja";
                Ovejas = new List<OvejaSummary>();

                for (int i = 0; i < 10; i++)
                {
                    var identificador = i + 1;
                    var ovejaDto = new OvejaSummary { Identificador = identificador, Nombre = $"{nombre}{identificador}" };
                    Ovejas.Add(ovejaDto);
                }
            }

            return Ovejas;
        }

        public static void InsertarOveja(OvejaSummary ovejaDto)
        {
            if (!Ovejas.Any(o => o.Identificador == ovejaDto.Identificador))
            {
                Ovejas.Add(ovejaDto);
            }
        }

        public static void EliminarOveja(int idOveja)
        {
            var oveja = Ovejas.FirstOrDefault(o => o.Identificador == idOveja);

            if (oveja != null)
            {
                Ovejas.Remove(oveja);
            }
        }

        public static void ModificarOveja(OvejaSummary ovejaDto)
        {
            var oveja = Ovejas.FirstOrDefault(o => o.Identificador == ovejaDto.Identificador);

            if (oveja != null)
            {
                oveja.Nombre = ovejaDto.Nombre;
            }
        }

        public static int SiguienteIdentifiador()
        {
            return Ovejas.Max(o => o.Identificador) + 1;
        }
    }
}
