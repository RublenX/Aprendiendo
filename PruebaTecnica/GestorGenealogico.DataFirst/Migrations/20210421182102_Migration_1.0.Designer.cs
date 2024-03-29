﻿// <auto-generated />
using System;
using GestorGenealogico.DataFirst.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GestorGenealogico.DataFirst.Migrations
{
    [DbContext(typeof(AcademiaContext))]
    [Migration("20210421182102_Migration_1.0")]
    partial class Migration_10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GestorGenealogico.DataFirst.Model.Alumno", b =>
                {
                    b.Property<int>("IdAlumno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CursoIdCurso")
                        .HasColumnType("int");

                    b.Property<int>("IdCurso")
                        .HasColumnType("int");

                    b.Property<DateTime>("Nacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAlumno");

                    b.HasIndex("CursoIdCurso");

                    b.ToTable("Alumnos");
                });

            modelBuilder.Entity("GestorGenealogico.DataFirst.Model.Curso", b =>
                {
                    b.Property<int>("IdCurso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdProfesor")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProfesorIdProfesor")
                        .HasColumnType("int");

                    b.HasKey("IdCurso");

                    b.HasIndex("ProfesorIdProfesor");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("GestorGenealogico.DataFirst.Model.Profesor", b =>
                {
                    b.Property<int>("IdProfesor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProfesor");

                    b.ToTable("Profesores");
                });

            modelBuilder.Entity("GestorGenealogico.DataFirst.Model.Alumno", b =>
                {
                    b.HasOne("GestorGenealogico.DataFirst.Model.Curso", "Curso")
                        .WithMany("Alumnos")
                        .HasForeignKey("CursoIdCurso");

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("GestorGenealogico.DataFirst.Model.Curso", b =>
                {
                    b.HasOne("GestorGenealogico.DataFirst.Model.Profesor", "Profesor")
                        .WithMany("Cursos")
                        .HasForeignKey("ProfesorIdProfesor");

                    b.Navigation("Profesor");
                });

            modelBuilder.Entity("GestorGenealogico.DataFirst.Model.Curso", b =>
                {
                    b.Navigation("Alumnos");
                });

            modelBuilder.Entity("GestorGenealogico.DataFirst.Model.Profesor", b =>
                {
                    b.Navigation("Cursos");
                });
#pragma warning restore 612, 618
        }
    }
}
