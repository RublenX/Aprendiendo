using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionObjetosNoEntidad
{
    public class RegistrosContext : DbContext
    {
        public DbSet<Registro> Registros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registro>()
                .HasData(
                    new Registro { RegistroId = 1, Nombre = "Primero", Identificador = Guid.NewGuid(), Capacidad = 25, Habilitado = true},
                    new Registro { RegistroId = 2, Nombre = "Segundo", Identificador = Guid.NewGuid(), Capacidad = 33, Habilitado = true},
                    new Registro { RegistroId = 3, Nombre = "Tercero", Identificador = Guid.NewGuid(), Capacidad = 66, Habilitado = false},
                    new Registro { RegistroId = 4, Nombre = "Cuarto", Identificador = Guid.NewGuid(), Capacidad = 45, Habilitado = true},
                    new Registro { RegistroId = 5, Nombre = "Quinto", Identificador = Guid.NewGuid(), Capacidad = 99, Habilitado = true},
                    new Registro { RegistroId = 6, Nombre = "Sexto", Identificador = Guid.NewGuid(), Capacidad = 1, Habilitado = true},
                    new Registro { RegistroId = 7, Nombre = "Séptimo", Identificador = Guid.NewGuid(), Capacidad = 14, Habilitado = false}
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=EFQuerying.ClientEvaluation;Trusted_Connection=True");
        }
    }
}
