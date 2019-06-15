using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFrmReferenciaExterna
{
    /// <summary>
    /// Entidad recuperada de la base de datos
    /// </summary>
    public class Usuarios
    {
        public int? ID { get; set; }
        public string Nombre { get; set; }
    }

    /// <summary>
    /// Entidad recuperada de la base de datos
    /// </summary>
    public class Ventas
    {
        public int IdVentas { get; set; }
        public decimal Precio { get; set; }
        public int IdUsuario { get; set; }
    }

    /// <summary>
    /// Entidad final de agrupación de resultados
    /// </summary>
    public class Usuario
    {
        public int? ID { get; set; }
        public string Nombre { get; set; }
        public List<Ventas> Ventas { get; set; }
    }


    public class LinQAgrupados2
    {
        public void Lanzar()
        {
            var usuariosDb = new List<Usuarios>
            {
                new Usuarios { ID = 1, Nombre = "Fulanito" },
                new Usuarios { ID = 2, Nombre = "Mengano"}
            };

            var ventasDb = new List<Ventas>
            {
                new Ventas{ IdVentas = 10, Precio = 11, IdUsuario = 1},
                new Ventas{ IdVentas = 11, Precio = 40, IdUsuario = 1},
                new Ventas{ IdVentas = 12, Precio = 5, IdUsuario = 2},
                new Ventas{ IdVentas = 13, Precio = 110, IdUsuario = 2}
            };

            var consulta1 = from u in usuariosDb
                            join v in ventasDb on u.ID equals v.IdUsuario
                            select new { u.ID, u.Nombre, v.IdVentas, v.Precio };

            var consulta2 = from u in usuariosDb
                            join v in ventasDb on u.ID equals v.IdUsuario into uv
                            select new Usuario { ID = u.ID, Nombre = u.Nombre, Ventas = uv.ToList() };

            var parada = consulta2.ToList();
        }
    }
}
