using EFEjemplo.EntityConfig;
using EFEjemplo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFEjemplo.Contexto
{
    public class ContextoDB : DbContext, IContextoDB
    {
        public ContextoDB(DbContextOptions<ContextoDB> options) : base(options)
        {
            // options se va a pasar por la inyección de dependencias del proyecto
        }

        public DbSet<Cancion> Canciones { get; set; }

        public DbSet<Album> Albumnes { get; set; }

        public DbSet<Autor> Autores { get; set; }

        // Sobrecarga para el modelo de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CancionEntityConfig.SetCancionEntityConfig(modelBuilder.Entity<Cancion>());

            // Esto sirve si queremos ponerle otro nombre a la tabla, en este caso le he puedo el mismo
            modelBuilder.Entity<Cancion>().ToTable("Canciones");
        }
    }
}
