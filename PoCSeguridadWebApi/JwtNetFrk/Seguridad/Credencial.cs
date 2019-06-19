using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JwtNetFrk.Seguridad
{
    public class Credencial
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}