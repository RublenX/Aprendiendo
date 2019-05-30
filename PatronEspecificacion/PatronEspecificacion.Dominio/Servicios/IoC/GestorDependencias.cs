using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Linq;
using McMaster.NETCore.Plugins;
using PatronEspecificacion.Dominio.Servicios.Interfaces;

namespace PatronEspecificacion.Dominio.Servicios.IoC
{
    public static class GestorDependencias
    {
        public static Type ObtenerTipoDependencia(string rutaEnsamblado, string tipoClase)
        {
            // Obtenido de https://natemcmaster.com/blog/2018/07/25/netcore-plugins/
            PluginLoader loader = PluginLoader.CreateFromAssemblyFile(rutaEnsamblado,
                        sharedTypes: new[] { typeof(IGestorDirecciones) });
            Assembly ensamblado = loader.LoadDefaultAssembly();

            // Código con AssemblyLoader que da conflicto por no cargar las librerías satélite
            //string directorioEnsamblado = Path.GetDirectoryName(rutaEnsamblado) + "\\";
            //AssemblyLoader assemblyLoader = new AssemblyLoader(directorioEnsamblado);
            //Assembly ensamblado = assemblyLoader.Load(rutaEnsamblado);

            return ensamblado.DefinedTypes.FirstOrDefault(t => t.FullName == tipoClase);

            /*
             * Código de ayuda para comprobar si una interfaz es implementada por una clase
             * Obtenido de : https://stackoverflow.com/questions/46228786/add-singleton-to-iservicecollection-dynamically-in-a-loop
             var humanTypes = typeof(IHuman).
            GetTypeInfo().Assembly.DefinedTypes
            .Where(t => typeof(IHuman).GetTypeInfo().IsAssignableFrom(t.AsType()) && t.IsClass)
            .Select(p => p.AsType());

            foreach(var humanType in humanTypes )
            {
                services.AddSingleton(humanType);
            }
            */
            //return null;
        }
    }
}
