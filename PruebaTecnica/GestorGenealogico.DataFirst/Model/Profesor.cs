using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestorGenealogico.DataFirst.Model
{
    public class Profesor
    {
        //Inicializamos el objeto de navegacion virtual de Entity Framework Core
        public Profesor()
        {
            Cursos = new HashSet<Curso>();
        }

        [Key]
        public int IdProfesor { get; set; } //Clave primaria

        public string Nombre { get; set; }

        //Entity Framewrok Core
        public ICollection<Curso> Cursos { get; set; } //Objeto de navegación virtual EFC
    }
}
