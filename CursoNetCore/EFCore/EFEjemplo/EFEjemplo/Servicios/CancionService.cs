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
            await _contextoDB.SaveChangesAsync();
        }

        public void AddCancion(Cancion cancion)
        {
            _contextoDB.Canciones.Add(cancion);
            _contextoDB.SaveChanges();
        }

        public void DeleteCancion(int cancionId)
        {
            var cancion = GetCancion(cancionId);
            if (cancion != null)
            {
                DeleteCancion(cancion);
            }
        }

        public void DeleteCancion(Cancion cancion)
        {
            _contextoDB.Canciones.Remove(cancion);
            _contextoDB.SaveChanges();
        }

        public List<Cancion> GetCanciones()
        {
            return _contextoDB.Canciones.ToList();
        }

        public Cancion GetCancion(int cancionId)
        {
            return _contextoDB.Canciones.Where(c => c.CancionId == cancionId).FirstOrDefault();
        }

        public Cancion UpdateCancion(Cancion cancion)
        {
            var resultado = _contextoDB.Canciones.Update(cancion).Entity;
            _contextoDB.SaveChanges();
            return resultado;
        }
    }
}
