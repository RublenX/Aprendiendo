using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EntidadesExtendidasConsole.Bases
{
    public class EntidadBase : ICloneable, IEquatable<EntidadBase>
    {
        #region Implementación ICloneable
        public virtual EntidadBase Clone()
        {
            // ATENCIÓN : Como no se puede predecir el comportamiento del método Clone se recomienda no
            // implementar ICloneable en APIs públicas
            // OJO para propiedades de colecciones, tipos por referencia o propiedades "IsReadOnly" hay que 
            // programarlo manualmente por esta razón se deja como "Virtual" el método, ya que MemberwiseClone 
            // tan sólo hace una copia superficial
            return this.MemberwiseClone() as EntidadBase;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }
        #endregion

        #region Implementación IEquatable
        public bool Equals(EntidadBase other)
        {
            if (other as object == null || GetType() != other.GetType())
            {
                return false;
            }

            Type tipo = this.GetType();

            foreach (PropertyInfo prop in tipo.GetProperties())
            {
                var valorEsperado = prop.GetValue(other);
                var valorRecibido = prop.GetValue(this);
                if (valorEsperado == null && valorRecibido != null)
                {
                    return false;
                }
                if (valorEsperado != null && valorRecibido == null)
                {
                    return false;
                }
                if (valorEsperado != null && valorRecibido != null)
                {
                    // Comprueba si la propiedad es algún tipo de array
                    var isGenericICollection = valorRecibido.GetType().GetInterfaces().Any(
                        x => x.IsGenericType &&
                        x.GetGenericTypeDefinition() == typeof(ICollection<>));
                    var isICollection = valorRecibido.GetType().GetInterfaces().Any(
                        x => x == typeof(ICollection));

                    if (isGenericICollection || isICollection)
                    {
                        ICollection coleccionEsperada = valorEsperado as ICollection;
                        ICollection coleccionRecibida = valorRecibido as ICollection;
                        if (coleccionEsperada.Count != coleccionRecibida.Count)
                        {
                            return false;
                        }

                        object[] listaEsperada = new object[coleccionEsperada.Count];
                        coleccionEsperada.CopyTo(listaEsperada, 0);
                        object[] listaRecibida = new object[coleccionRecibida.Count];
                        coleccionRecibida.CopyTo(listaRecibida, 0);

                        for (int i = 0; i < coleccionRecibida.Count; i++)
                        {
                            if(!listaRecibida[i].Equals(listaEsperada[i]))
                            {
                                return false;
                            }
                        }
                    }
                    else if(!valorEsperado.Equals(valorRecibido))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion

        #region Sobrecarga de Métodos
        public override int GetHashCode()
        {
            int hashCode = 0;

            foreach (PropertyInfo prop in this.GetType().GetProperties())
            {
                object value = prop.GetValue(this);
                if (value != null)
                {
                    // Comprueba si la propiedad es algún tipo de array
                    var isGenericICollection = value.GetType().GetInterfaces().Any(
                        x => x.IsGenericType &&
                        x.GetGenericTypeDefinition() == typeof(ICollection<>));
                    var isICollection = value.GetType().GetInterfaces().Any(
                        x => x == typeof(ICollection));

                    if (isGenericICollection || isICollection)
                    {
                        ICollection col = value as ICollection;
                        foreach (var valueColeccion in col)
                        {
                            // Se recorre los objetos del array obteniendo su código hash
                            hashCode = CrearHash(hashCode, valueColeccion);
                        }
                    }
                    else
                    {
                        hashCode = CrearHash(hashCode, value);
                    }
                }
            }

            return hashCode;
        }

        public override bool Equals(object obj)
        {
            // Se sobreescribe el método para poder comprobar si dos objetos de la misma clase tienen las mismas propiedades
            return Equals(obj as EntidadBase);
        }

        public override string ToString()
        {
            // Este no hace falta pero lo he incluido para depurar las variables
            try
            {
                return JsonConvert.SerializeObject(this, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return base.ToString() + $" - Excepción obteniendo los valores de las propiedades: {ex.Message}";
            }
        }
        #endregion

        #region Codificación de operadores
        public static bool operator ==(EntidadBase obj1, EntidadBase obj2)
        {
            if (obj1 as object == null && obj2 as object == null)
            {
                return true;
            }
            if (obj1 as object == null && obj2 as object != null)
            {
                return false;
            }
            return obj1.Equals(obj2);
        }

        public static bool operator !=(EntidadBase obj1, EntidadBase obj2)
        {
            if (obj1 as object == null && obj2 as object == null)
            {
                return false;
            }
            if (obj1 as object == null && obj2 as object != null)
            {
                return true;
            }
            return !obj1.Equals(obj2);
        }
        #endregion

        #region Métodos Auxiliares
        private static int CrearHash(int hashCode, object value)
        {
            if (hashCode == 0)
            {
                hashCode = value.GetHashCode();
            }
            else
            {
                hashCode = hashCode ^ value.GetHashCode();
            }

            return hashCode;
        }

        #endregion
    }
}
