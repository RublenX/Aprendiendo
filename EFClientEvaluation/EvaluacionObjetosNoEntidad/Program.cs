using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluacionObjetosNoEntidad
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new RegistrosContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            using (var context = new RegistrosContext())
            {
                var listaClases = new List<ClaseNoEntidad> {
                    new ClaseNoEntidad { Cantidad = 25, Habilitado = true },
                    new ClaseNoEntidad { Cantidad = 14, Habilitado = false }
                };

                try
                {
                    var consulta = context.Registros.Where(r => listaClases.Any(l => l.Cantidad == r.Capacidad && l.Habilitado == r.Habilitado));
                    var resultado = consulta.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                try
                {
                    var lista = listaClases.Select(l => l.Cantidad);
                    var consulta2 = context.Registros.Where(r => lista.Any(l => l == r.Capacidad));
                    var resultado2 = consulta2.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("---- Fin de Ejecución ----");
        }
    }
}
