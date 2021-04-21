using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Handlers.Ovejas.Command
{
    public class OvejaDelete : IRequest
    {
        public int Identificador { get; set; }
    }
}
