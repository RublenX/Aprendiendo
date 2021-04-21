using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GestorGenealogico.Data.Modelo;

#nullable disable

namespace GestorGenealogico.Data.Contexto
{
    public partial class InventadaContext : DbContext
    {
        public InventadaContext()
        {
        }

        public InventadaContext(DbContextOptions<InventadaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Genealogia> Genealogia { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<TipoParentesco> TipoParentesco { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=Inventada;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Genealogia>(entity =>
            {
                entity.HasOne(d => d.IdPersona1Navigation)
                    .WithMany(p => p.GenealogiaIdPersona1Navigation)
                    .HasForeignKey(d => d.IdPersona1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Genealogia_Persona");

                entity.HasOne(d => d.IdPersona2Navigation)
                    .WithMany(p => p.GenealogiaIdPersona2Navigation)
                    .HasForeignKey(d => d.IdPersona2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Genealogia_Persona1");

                entity.HasOne(d => d.IdTipoParentescoNavigation)
                    .WithMany(p => p.Genealogia)
                    .HasForeignKey(d => d.IdTipoParentesco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Genealogia_TipoParentesco");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.Property(e => e.Id).HasComment("Identificador principal");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
