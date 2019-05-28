using Microsoft.EntityFrameworkCore;
using PatronEspecificacion.InfraestructuraDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatronEspecificacion.InfraestructuraDatos.Persistencia
{
    public class PoCEspecificacionContext : DbContext
    {
        #region Declaración de Tablas
        public DbSet<Direccion> Direcciones { get; set; }
        #endregion

        #region Configuración
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=PoCEspecificacion;Integrated Security=True");
        }
        #endregion
    }
}
