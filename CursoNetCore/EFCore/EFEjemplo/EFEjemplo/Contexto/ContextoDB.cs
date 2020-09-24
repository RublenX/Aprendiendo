using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFEjemplo.Contexto
{
    public class ContextoDB : DbContext
    {
        public ContextoDB(DbContextOptions<ContextoDB> options) : base(options)
        {
            // options se va a pasar por la inyección de dependencias del proyecto
        }

        // Sobrecarga para el modelo de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
