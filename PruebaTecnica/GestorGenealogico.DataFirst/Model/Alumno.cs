using System;
using System.ComponentModel.DataAnnotations;

namespace GestorGenealogico.DataFirst.Model
{
    public class Alumno
    {
        [Key]
        public int IdAlumno { get; set; } //Clave primaria

        public string Nombre { get; set; }

        public DateTime Nacimiento { get; set; }

        public int IdCurso { get; set; } //Campo clave foranea

        //Entity Framewrok Core
        public Curso Curso { get; set; } //Objeto de navegación virtual EFC
    }
}
