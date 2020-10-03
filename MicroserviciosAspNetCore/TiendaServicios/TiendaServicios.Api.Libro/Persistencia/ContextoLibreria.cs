using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Modelo;

namespace TiendaServicios.Api.Libro.Persistencia
{
    public class ContextoLibreria : DbContext
    {
        // Creamos el contructor para poder instanciarlo desde los proyecto de pruebas
        public ContextoLibreria() { }

        public ContextoLibreria(DbContextOptions<ContextoLibreria> options) : base(options) { }

        // La hacemos virtual para poder sobreescribirla de cara a las pruebas
        public virtual DbSet<LibreriaMaterial> LibreriaMaterial { get; set; }
    }
}
