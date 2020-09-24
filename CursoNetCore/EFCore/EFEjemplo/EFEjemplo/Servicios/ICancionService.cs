using EFEjemplo.Models;
using System.Threading.Tasks;

namespace EFEjemplo.Servicios
{
    public interface ICancionService
    {
        Task AddCancionAsync(Cancion cancion);

        void AddCancion(Cancion cancion);
    }
}
