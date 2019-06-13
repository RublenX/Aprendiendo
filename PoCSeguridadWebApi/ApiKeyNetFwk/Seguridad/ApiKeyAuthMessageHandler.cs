using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace ApiKeyNetFwk.Seguridad
{
    public class ApiKeyAuthMessageHandler : DelegatingHandler
    {
        /// <summary>
        /// Listado de API Keys autorizadas
        /// </summary>
        private readonly Dictionary<string, Guid> ApiKeys = GestorApiKeys.GetKeys();


        /// <summary>
        /// Cabecera http que indica que contiene la Key de la API
        /// </summary>
        private const string API_KEY = "API_KEY";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
        {
            // Para obtener la API Key
            IEnumerable<string> listaCabeceras;
            var existeCabeceraApiKey = request.Headers.TryGetValues(API_KEY, out listaCabeceras);
            if (existeCabeceraApiKey && listaCabeceras.Any())
            {
                // El descriptor aquí contendrá información sobre el controlador al que se enrutará la solicitud.
                // Si es nulo (es decir, no se encontró el controlador), se lanzará una excepción
                var config = GlobalConfiguration.Configuration;
                var controllerSelector = new DefaultHttpControllerSelector(config);
                var controller = controllerSelector.SelectController(request);

                if (controller != null && ApiKeys.ContainsKey(controller.ControllerName))
                {
                    // Recupera el Guid de la API para comprobar su autenticación
                    Guid apiKey = ApiKeys[controller.ControllerName];
                    if (listaCabeceras.First().Equals(apiKey.ToString()))
                    {
                        // Valida el acceso a la API
                        var principal = new GenericPrincipal(new GenericIdentity("Auth_" + controller.ControllerName), null);
                        AutorizarAccesoApi(principal);
                    }
                }
            }

            return base.SendAsync(request, cancellationToken);
        }

        private void AutorizarAccesoApi(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }
    }
}