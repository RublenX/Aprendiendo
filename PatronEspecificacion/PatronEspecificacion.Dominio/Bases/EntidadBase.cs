﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

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
                if (!valorEsperado.Equals(valorRecibido))
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
            StringBuilder strBld = new StringBuilder();

            try
            {
                foreach (var prop in this.GetType().GetProperties())
                {
                    if (!prop.GetMethod.IsVirtual)
                    {
                        string separador = strBld.Length > 0 ? " | " : string.Empty;
                        strBld.Append($"{separador}[{prop.Name}] : {prop.GetValue(this)}");
                    }
                }
            }
            catch (Exception ex)
            {
                return base.ToString() + $" - Excepción obteniendo los valores de las propiedades: {ex.Message}";
            }

            return strBld.ToString();
        }

        public virtual object Clone()
        {
            // OJO para propiedades de colecciones o tipos por referencia hay que programarlo manualmente
            object copia = this.MemberwiseClone();

            return copia;
        }
    }
}