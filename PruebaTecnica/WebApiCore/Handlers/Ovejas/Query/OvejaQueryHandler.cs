using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiCore.Datos;
using WebApiCore.Handlers.Ovejas.Command;

namespace WebApiCore.Handlers.Ovejas.Query
{
    public class OvejaQueryHandler : IRequestHandler<OvejaFilter, List<OvejaSummary>>
    {
        public async Task<List<OvejaSummary>> Handle(OvejaFilter request, CancellationToken cancellationToken)
        {
            List<OvejaSummary> resultado = new List<OvejaSummary>();

            // En este primera prueba el filtro no lo tengo en cuenta y devuelto un array de ovejas
            List<OvejaSummary> ovejasDto = await Task.Run(() => OvejasService.DameOvejas());

            if (!string.IsNullOrEmpty(request.Nombre))
            {

                resultado = ovejasDto.Where(o => o.Nombre == request.Nombre).ToList();
            }
            else
            {
                resultado = ovejasDto;
            }

            return resultado;
        }
    }
}
