using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFrmReferenciaExterna
{
    public class TablaPoc1
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Cantidad { get; set; }
    }

    public class AccesoDatos
    {
        public void LanzarExecuteReader()
        {
            // Variables locales
            string cadenaConex = @"Data Source=.\SQLEXPRESS;Initial Catalog=Db1;Integrated Security=True";
            List<TablaPoc1> lista = new List<TablaPoc1>();
            int codError = 0;
            int returnValue = 0;

            // Se utiliza la instrucción using para asegurarnos la desctrucción de los objetos y liberar recursos
            using (SqlConnection con = new SqlConnection(cadenaConex))
            {
                using (SqlCommand com = new SqlCommand())
                {
                    try
                    {
                        // Al comando se le asigna una conexión
                        com.Connection = con;

                        // Se le indica el tipo de comando y el nombre
                        com.CommandType = CommandType.StoredProcedure;
                        com.CommandText = "CantidadesMayoresPorUsuario";

                        // Se añaden los parámetros de entrada
                        com.Parameters.AddWithValue("@idUsuario", DBNull.Value);
                        com.Parameters.AddWithValue("@cantidadMayorQue", 5);

                        // Se añaden los parámetros de salida y se crean variables para facilitar su recuperacion
                        SqlParameter paramOutCodError = com.Parameters.Add("@codError", SqlDbType.Int, int.MaxValue);
                        paramOutCodError.Direction = ParameterDirection.Output;
                        SqlParameter paramReturned = com.Parameters.Add("@return_value", SqlDbType.Int, int.MaxValue);
                        paramReturned.Direction = ParameterDirection.ReturnValue;

                        // Se abre la conexión
                        con.Open();

                        // Se recupera el lector de datos al utilizar ExecuteReader
                        SqlDataReader lector = com.ExecuteReader();

                        // Mientras no terminer de leer filas ejecuta recupera la información obtenida
                        while (lector.Read())
                        {
                            // Creamos un objeto con los parámetros obtenidos de la consulta
                            TablaPoc1 fila = new TablaPoc1
                            {
                                Id = lector["Id"] != DBNull.Value ? (int)lector["Id"] : 0,
                                Nombre = lector["Nombre"] != DBNull.Value ? (string)lector["Nombre"] : string.Empty,
                                Fecha = lector["Fecha"] != DBNull.Value ? (DateTime)lector["Fecha"] : DateTime.MinValue,
                                Cantidad = lector["Cantidad"] != DBNull.Value ? (decimal)lector["Cantidad"] : 0
                            };

                            // Añadimos la fila al listado
                            lista.Add(fila);
                        }

                        // Se cierrra el lector de datos para poder recuperar los parámetros de salida
                        lector.Close();

                        // Se recuperan los parámetros de salida
                        codError = (paramOutCodError.Value != null && paramOutCodError.Value != DBNull.Value) ? (int)paramOutCodError.Value : 0;
                        returnValue = (paramOutCodError.Value != null && paramReturned.Value != DBNull.Value) ? (int)paramReturned.Value : 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR : " + ex.Message);
                    }
                    finally
                    {
                        // Nos aseguramos de cerrar la conexión en caso de error
                        con.Close();
                    }
                }
            }

            // Variable para poner un punto de parada de depuración y ver los resultados
            int parada = lista.Count;

        }

        public void LanzarConTrasaccion()
        {
            // Variables locales
            string cadenaConex = @"Data Source=.\SQLEXPRESS;Initial Catalog=Db1;Integrated Security=True";

            // Se utiliza la instrucción using para asegurarnos la desctrucción de los objetos y liberar recursos
            using (SqlConnection con = new SqlConnection(cadenaConex))
            {
                try
                {
                    // Se abre la conexión
                    con.Open();

                    // Se prepara una transacción por si acaso falla la ejecución haya una vuelta atrás
                    using (var trans = con.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand com = new SqlCommand())
                            {
                                // Al comando se le asigna una conexión y la transacción
                                com.Connection = con;
                                com.Transaction = trans;

                                // Se le indica el tipo de comando y el nombre
                                com.CommandType = CommandType.StoredProcedure;
                                com.CommandText = "CrearRegistro";

                                // Se añaden los parámetros de entrada
                                com.Parameters.AddWithValue("@Nombre", "Fulano");
                                com.Parameters.AddWithValue("@Cantidad", 69);

                                // Se ejecuta el procedimiento y se comprueba la salida
                                var registrosAfectados = com.ExecuteNonQuery();
                            }

                            using (SqlCommand com = new SqlCommand())
                            {
                                // Al comando se le asigna una conexión y la transacción
                                com.Connection = con;
                                com.Transaction = trans;

                                // Se le indica el tipo de comando y el nombre
                                com.CommandType = CommandType.StoredProcedure;
                                com.CommandText = "ActualizarRegistro";

                                // Se añaden los parámetros de entrada
                                com.Parameters.AddWithValue("@Id", 1);
                                com.Parameters.AddWithValue("@Fecha", DateTime.Now);

                                // Se ejecuta el procedimiento y se comprueba la salida
                                var registrosAfectados = com.ExecuteNonQuery();
                            }

                            trans.Commit();
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            Console.WriteLine("ERROR : " + ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR : " + ex.Message);
                }
                finally
                {
                    // Nos aseguramos de cerrar la conexión en caso de error
                    con.Close();
                }
            }
        }
    }
}
