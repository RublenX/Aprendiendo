using EntidadesExtendidasConsole.Bases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesExtendidasConsole.Entidades
{
    public class EntidadCompleja : EntidadBase
    {
        #region Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<string> Coleccion1 { get; set; }
        public string[] Coleccion2 { get; set; }
        public ArrayList Coleccion3 { get; set; }
        public EntidadSimple Simple { get; set; }
        public DateTime Fecha { get; set; }
        #endregion

        #region Sobrecarga de métodos
        public override EntidadBase Clone()
        {
            EntidadCompleja copia = base.Clone() as EntidadCompleja;

            // Inicialización de propiedades de tipo referencia
            copia.Coleccion1 = null;
            copia.Simple = null;

            // Copia de valores si los objetos no son nulos
            if (this.Coleccion1 != null)
            {
                copia.Coleccion1 = this.Coleccion1.ToList();
            }

            if (this.Coleccion2 != null)
            {
                copia.Coleccion2 = this.Coleccion2.ToArray();
            }

            if (this.Coleccion3 != null)
            {
                copia.Coleccion3 = this.Coleccion3.Clone() as ArrayList;
            }

            if (this.Simple != null)
            {
                copia.Simple = this.Simple.Clone() as EntidadSimple;
            }

            return copia;
        }
        #endregion
    }
}
