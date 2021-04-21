using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestorGenealogico.DataFirst.Model
{
    public class Curso
    {
        //Inicializamos el objeto de navegacion virtual de Entity Framework Core
        public Curso()
        {
            Alumnos = new HashSet<Alumno>();
        }

        [Key]
        public int IdCurso { get; set; } //Clave primaria

        public string Nombre { get; set; }

        public string Ciudad { get; set; }

        public int IdProfesor { get; set; } //Campo clave foranea

        //Entity Framewrok Core
        public Profesor Profesor { get; set; } //Objeto de navegación virtual EFC

        public ICollection<Alumno> Alumnos { get; set; } //Objeto de navegación virtual EFC
    }
}
