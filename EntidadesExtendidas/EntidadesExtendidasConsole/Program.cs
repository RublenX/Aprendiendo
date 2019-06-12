using EntidadesExtendidasConsole.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;

namespace EntidadesExtendidasConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("┌────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                          Entidades Extendidas PoC                          │");
            Console.WriteLine("└────────────────────────────────────────────────────────────────────────────┘");

            try
            {
                #region Pruebas ICloneable
                // Clonado de la entidad simple
                EntidadSimple entSim = new EntidadSimple
                {
                    Id = 1,
                    Descripcion = "Simple 1"
                };

                EntidadSimple entSimCopia = entSim.Clone() as EntidadSimple;
                entSimCopia.Id = 2;
                entSimCopia.Descripcion = "Simple 2";
                if (entSim.Descripcion == entSimCopia.Descripcion)
                {
                    Console.WriteLine("¡Vaya no ha hecho bien la copia simple!");
                }
                else
                {
                    Console.WriteLine("Clonado de la entidad simple correcto.");
                }

                // Clonado de la entidad compleja
                bool clonadoComplejoCorrecto = true;
                EntidadCompleja entCom = new EntidadCompleja
                {
                    Id = 1,
                    Nombre = "Compleja 1",
                    Coleccion1 = new List<string> { "Primero", "Segundo" },
                    Coleccion2 = new string[] { "AAAA", "BBBB" },
                    Coleccion3 = new ArrayList() { "1111", "2222" },
                    Simple = entSim,
                    Fecha = new DateTime(2019, 6, 10)
                };

                EntidadCompleja entComCopia = entCom.Clone() as EntidadCompleja;
                entComCopia.Id = 2;
                if (entCom.Id == entComCopia.Id)
                {
                    clonadoComplejoCorrecto = false;
                    Console.WriteLine("¡Vaya no ha hecho bien la copia simple!");
                }

                entComCopia.Coleccion1[0] = "Tercero";
                if (entCom.Coleccion1[0] == entComCopia.Coleccion1[0])
                {
                    clonadoComplejoCorrecto = false;
                    Console.WriteLine("¡Vaya no ha hecho bien la copia del listado 1!");
                }

                entComCopia.Coleccion2[0] = "CCCC";
                if (entCom.Coleccion2[0] == entComCopia.Coleccion2[0])
                {
                    clonadoComplejoCorrecto = false;
                    Console.WriteLine("¡Vaya no ha hecho bien la copia del listado 2!");
                }

                entComCopia.Coleccion3[0] = "3333";
                if (entCom.Coleccion3[0] == entComCopia.Coleccion3[0])
                {
                    clonadoComplejoCorrecto = false;
                    Console.WriteLine("¡Vaya no ha hecho bien la copia del listado 2!");
                }

                entComCopia.Simple.Id = 3;
                if (entCom.Simple.Id == entComCopia.Simple.Id)
                {
                    clonadoComplejoCorrecto = false;
                    Console.WriteLine("¡Vaya no ha hecho bien la copia del objeto!");
                }

                entComCopia.Fecha = entComCopia.Fecha.AddDays(1);
                if (entCom.Fecha == entComCopia.Fecha)
                {
                    clonadoComplejoCorrecto = false;
                    Console.WriteLine("¡Vaya no ha hecho bien la copia de la fecha!");
                }

                if (clonadoComplejoCorrecto)
                {
                    Console.WriteLine("Clonado de la entidad compleja correcto.");
                }
                #endregion

                #region Pruebas Hash
                entSimCopia = entSim.Clone() as EntidadSimple;
                int hash1s = entSim.GetHashCode();
                int hash2s = entSimCopia.GetHashCode();


                Dictionary<EntidadCompleja, object> dic = new Dictionary<EntidadCompleja, object>();
                entComCopia = entCom.Clone() as EntidadCompleja;
                int hash1 = entCom.GetHashCode();
                int hash2 = entComCopia.GetHashCode();
                bool sonIguales = entCom == entComCopia;
                dic.Add(entCom, "Uno");
                if(!dic.ContainsKey(entComCopia))
                {
                    dic.Add(entComCopia, "Dos");
                    Console.WriteLine("Si pasa por aquí es que se ha duplicado la entidad en el diccionario.");
                }
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR : {ex.Message}");
            }
        }
    }
}
