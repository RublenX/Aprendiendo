using System;
using System.Reflection;
using System.Linq;

namespace PatronEspecificacion.Dominio.Servicios.IoC
{
    public static class GestorDependencias
    {
        public static Type ObtenerTipoDependencia(Type tipoContrato, string rutaEnsamblado, string tipoClase)
        {
            // SORPRESA se debe hacer con LoadFrom para que cargue las librerías dependientes
            // https://stackoverflow.com/questions/181901/reflection-net-how-to-load-dependencies
            // Para extraer más información se puede usar IsAssignableFrom
            //https://stackoverflow.com/questions/46228786/add-singleton-to-iservicecollection-dynamically-in-a-loop
            Assembly ensamblado = Assembly.LoadFrom(rutaEnsamblado);
            Type tipoImplementador = ensamblado.DefinedTypes.FirstOrDefault(t => t.FullName == tipoClase);

            return ensamblado.DefinedTypes.FirstOrDefault(t => t.FullName == tipoClase);
        }
    }
}
