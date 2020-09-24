using EFEjemplo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFEjemplo.Servicios
{
    public interface ICancionService
    {
        Task AddCancionAsync(Cancion cancion);

        void AddCancion(Cancion cancion);

        void DeleteCancion(int cancionId);

        void DeleteCancion(Cancion cancion);

        List<Cancion> GetCanciones();

        Cancion GetCancion(int cancionId);

        Cancion UpdateCancion(Cancion cancion);
    }
}
