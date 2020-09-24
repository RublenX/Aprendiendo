using EFEjemplo.Contexto;
using EFEjemplo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFEjemplo.Servicios
{
    public class CancionService : ICancionService
    {
        public readonly IContextoDB _contextoDB;

        public CancionService(IContextoDB contextoDB)
        {
            _contextoDB = contextoDB;
        }

        public async Task AddCancionAsync(Cancion cancion)
        {
            _contextoDB.Canciones.Add(cancion);
            int numElementosGuardados = await _contextoDB.SaveChangesAsync();
        }

        public void AddCancion(Cancion cancion)
        {
            _contextoDB.Canciones.Add(cancion);
            _contextoDB.SaveChanges();
        }
    }
}
