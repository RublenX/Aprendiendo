using Newtonsoft.Json;
using System;
using System.Reflection;

namespace PatronEspecificacion.Dominio.Bases
{
    public interface IEntidadBase : ICloneable, IEquatable<IEntidadBase>
    {
        int GetHashCode();
        bool Equals(object obj);
    }

    /// <summary>
    /// Extiende las entidades para poder comprobar la igualdad entre objetos, clonarlos y 
    /// también la manipulación de los mismos en listas y diccionarios, se debe tener especial cuidado 
    /// con las propiedades de colecciones o tipos por referencia hay que programarlo manualmente
    /// sobreescribiendo el método "Clone"
    /// </summary>
    /// <typeparam name="T">Tipo genérico de tipo clase</typeparam>
    public class EntidadBase : IEntidadBase, ICloneable, IEquatable<EntidadBase>
    {
        public override int GetHashCode()
        {
            int hashCode = 0;

            foreach (PropertyInfo prop in this.GetType().GetProperties())
            {
                object value = prop.GetValue(this);
                if (value != null)
                {
                    if (hashCode == 0)
                    {
                        hashCode = value.GetHashCode();
                    }
                    else
                    {
                        hashCode = hashCode ^ value.GetHashCode();
                    }
                }
            }

            return hashCode;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as EntidadBase);
        }

        public bool Equals(EntidadBase obj)
        {
            // Se sobreescribe el método para poder comprobar si dos objetos de la misma clase tienen las mismas propiedades
            if (obj as object == null || GetType() != obj.GetType())
            {
                return false;
            }

            Type tipo = this.GetType();

            foreach (PropertyInfo prop in tipo.GetProperties())
            {
                var valorEsperado = prop.GetValue(obj);
                var valorRecibido = prop.GetValue(this);
                if (valorEsperado == null && valorRecibido != null)
                {
                    return false;
                }
                if (valorEsperado != null && valorRecibido == null)
                {
                    return false;
                }
                if (valorEsperado != null && valorRecibido != null && !valorEsperado.Equals(valorRecibido))
                {
                    return false;
                }
            }

            return true;
        }

        public bool Equals(IEntidadBase other)
        {
            return this.Equals(other);
        }

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
            bool iguales = object.ReferenceEquals(obj1, obj2);
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

        public override string ToString()
        {
            try
            {
                return JsonConvert.SerializeObject(this, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return base.ToString() + $" - Excepción obteniendo los valores de las propiedades: {ex.Message}";
            }
        }

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
    }
}
