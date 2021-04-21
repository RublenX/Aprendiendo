using GestorGenealogico.DataFirst.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorGenealogico.DataFirst.Context
{
    public class AcademiaContext : DbContext
    {
        #region Ciclo de Vida
        public AcademiaContext() { }

        public AcademiaContext(DbContextOptions options) : base(options) { }
        #endregion

        #region Métodos Protegidos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=Academia;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }
        #endregion

        #region Tablas
        public virtual DbSet<Alumno> Alumnos { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<Profesor> Profesores { get; set; }
        #endregion
    }
}
