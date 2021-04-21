using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiCore.Datos;

namespace WebApiCore.Handlers.Ovejas.Command
{
    public class OvejaCommandHandler : IRequestHandler<OvejaSummary>, IRequestHandler<OvejaDelete>
    {
        public async Task<Unit> Handle(OvejaSummary request, CancellationToken cancellationToken)
        {
            if (request.Identificador > 0)
            {
                // Comando de modificación
                await Task.Run(() => OvejasService.ModificarOveja(request));
            }
            else
            {
                // Comando de insercción

                request.Identificador = OvejasService.SiguienteIdentifiador();
                await Task.Run(() => OvejasService.InsertarOveja(request));
            }

            return Unit.Value;
        }

        public async Task<Unit> Handle(OvejaDelete request, CancellationToken cancellationToken)
        {
            await Task.Run(() => OvejasService.EliminarOveja(request.Identificador));

            return Unit.Value;
        }
    }
}
