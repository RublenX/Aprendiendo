using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Handlers.Ovejas.Command
{
    public class OvejaSummary : IRequest
    {
        public int Identificador { get; set; }

        public string Nombre { get; set; }
    }
}
