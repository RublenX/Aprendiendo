using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class Consulta
    {
        /// <summary>
        /// Clase que se encarga de indicar la entrada y la salida (indicándoselo en IRequest)
        /// </summary>
        public class ListaAutor : IRequest<List<AutorLibro>> { }

        /// <summary>
        /// Clase que se encarga de manejar la solicitud al controlador e implementa la lógica de negocio, hay que indicarle la entra y la salida
        /// </summary>
        public class Manejador : IRequestHandler<ListaAutor, List<AutorLibro>>
        {
            private readonly ContextoAutor _contexto;

            public Manejador(ContextoAutor contexto)
            {
                _contexto = contexto;
            }

            public async Task<List<AutorLibro>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                var autores = await _contexto.AutorLibro.ToListAsync();

                return autores;
            }
        }
    }
}
