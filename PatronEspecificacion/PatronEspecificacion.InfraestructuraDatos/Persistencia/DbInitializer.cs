using PatronEspecificacion.InfraestructuraDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace PatronEspecificacion.InfraestructuraDatos.Persistencia
{
    public static class DbInitializer
    {
        public static void Initialize(PoCEspecificacionContext context)
        {
            if (context == null)
            {
                context = new PoCEspecificacionContext();
            }

            Console.WriteLine("Comprobado la existencia de la base de datos...");
            // Se asegura que la base de datos está creada y si no es así la crea
            bool creada = context.Database.EnsureCreated();
            if (creada)
            {
                Console.WriteLine("Se ha generado la base de datos\r\n");

                Console.WriteLine("Generando datos iniciales...");
                // Inicializa la base de datos
                InsertarDatos(context);
                Console.WriteLine("Datos iniciales generados correctamente\r\n");
            }
            else
            {
                Console.WriteLine("BBDD Existe\r\n");
            }
        }

        public static void InsertarDatos(PoCEspecificacionContext context)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // NOTA : Es más óptimo array [] que List<T>
                // Si se usa la función context.<Entidad>.Single hay que usar previamente SaveChanges
                var direcciones = new Direccion[]
                {
                    new Direccion
                    {
                        Pais = "España",
                        ComunidadAutonoma = "Madrid",
                        Provincia = "Madrid",
                        Municipio = "Madrid",
                        Calle = "Paseo de la Castellana"
                    },
                    new Direccion
                    {
                        Pais = "España",
                        ComunidadAutonoma = "Castilla la Mancha",
                        Provincia = "Guadalajara",
                        Municipio = "Cabanillas del Campo",
                        Calle = "Calle Benalaque"
                    },
                    new Direccion
                    {
                        Pais = "España",
                        ComunidadAutonoma = "Castilla la Mancha",
                        Provincia = "Guadalajara",
                        Municipio = "Cabanillas del Campo",
                        Calle = "Calle Madrid"
                    },
                    new Direccion
                    {
                        Pais = "España",
                        ComunidadAutonoma = "Castilla la Mancha",
                        Provincia = "Cuenca",
                        Municipio = "Cañaveras",
                        Calle = "Calle del Cura"
                    },
                    new Direccion
                    {
                        Pais = "España",
                        ComunidadAutonoma = "Castilla la Mancha",
                        Provincia = "Cuenca",
                        Municipio = "Cañaveras",
                        Calle = "Calle Real"
                    },
                    new Direccion
                    {
                        Pais = "España",
                        ComunidadAutonoma = "Castilla la Mancha",
                        Provincia = "Cuenca",
                        Municipio = "Cañaveras",
                        Calle = "Calle Garcibela"
                    },
                    new Direccion
                    {
                        Pais = "España",
                        ComunidadAutonoma = "Madrid",
                        Provincia = "Madrid",
                        Municipio = "Madrid",
                        Calle = "Calle Ferrocarril"
                    },
                    new Direccion
                    {
                        Pais = "España",
                        ComunidadAutonoma = "Madrid",
                        Provincia = "Madrid",
                        Municipio = "Madrid",
                        Calle = "Avenida de América"
                    },
                    new Direccion
                    {
                        Pais = "España",
                        ComunidadAutonoma = "Madrid",
                        Provincia = "Madrid",
                        Municipio = "Madrid",
                        Calle = "Calle Real"
                    },
                    new Direccion
                    {
                        Pais = "España",
                        ComunidadAutonoma = "Madrid",
                        Provincia = "Madrid",
                        Municipio = "Alcobendas",
                        Calle = "Calle Jarama"
                    },
                    new Direccion
                    {
                        Pais = "España",
                        ComunidadAutonoma = "Madrid",
                        Provincia = "Madrid",
                        Municipio = "San Sebastián de los Reyes",
                        Calle = "Paseo de Europa"
                    },
                    new Direccion
                    {
                        Pais = "España",
                        ComunidadAutonoma = "Madrid",
                        Provincia = "Madrid",
                        Municipio = "San Sebastián de los Reyes",
                        Calle = "Avenida de la Sierra"
                    },
                    new Direccion
                    {
                        Pais = "España",
                        ComunidadAutonoma = "Valencia",
                        Provincia = "Valencia",
                        Municipio = "Oliva",
                        Calle = "Calle del Soroller"
                    },
                    new Direccion
                    {
                        Pais = "España",
                        ComunidadAutonoma = "Valencia",
                        Provincia = "Valencia",
                        Municipio = "Oliva",
                        Calle = "Calle del Romer"
                    },
                    new Direccion
                    {
                        Pais = "España",
                        ComunidadAutonoma = "Valencia",
                        Provincia = "Valencia",
                        Municipio = "Oliva",
                        Calle = "Carrer del Governador"
                    },
                };
                foreach (var direccion in direcciones)
                {
                    context.Direcciones.Add(direccion);
                }
                context.SaveChanges();

                scope.Complete();
            }
        }
    }
}
