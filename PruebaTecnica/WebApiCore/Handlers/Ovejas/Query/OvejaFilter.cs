using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.Handlers.Ovejas.Command;

namespace WebApiCore.Handlers.Ovejas.Query
{
    public class OvejaFilter : IRequest<List<OvejaSummary>>
    {
        public string Nombre { get; set; }
    }
}
