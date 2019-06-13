using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ApiKeyNetFwk.Seguridad
{
    internal static class GestorApiKeys
    {
        public static Dictionary<string, Guid> GetKeys()
        {
            Dictionary<string, Guid> resultado = new Dictionary<string, Guid>();

            var rutaFicheroConfig = Path.Combine(HttpRuntime.AppDomainAppPath, "ApiKeysConfig.json");
            if (File.Exists(rutaFicheroConfig))
            {
                var serializado = File.ReadAllText(rutaFicheroConfig);
                resultado = JsonConvert.DeserializeObject<Dictionary<string, Guid>>(serializado);
            }

            return resultado;
        }
    }
}