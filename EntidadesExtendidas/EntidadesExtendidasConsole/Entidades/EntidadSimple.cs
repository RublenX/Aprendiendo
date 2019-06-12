using EntidadesExtendidasConsole.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesExtendidasConsole.Entidades
{
    public class EntidadSimple : EntidadBase
    {
        #region Propiedades
        public int Id { get; set; }
        public string Descripcion { get; set; }
        #endregion
    }
}
