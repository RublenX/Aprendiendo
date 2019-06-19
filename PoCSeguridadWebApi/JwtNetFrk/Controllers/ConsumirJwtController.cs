using JwtNetFrk.Seguridad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace JwtNetFrk.Controllers
{
    public class ConsumirJwtController : ApiController
    {
        public async Task<IHttpActionResult> Get()
        {
            // Se obtiene el token
            ProveedorJwt jwTokenProv = new ProveedorJwt();
            string token = jwTokenProv.GenerarToken(
                new Credencial
                {
                    IdUsuario = 1,
                    Nombre = "nombre usuario",
                    CorreoElectronico = "anonimo@email.es",
                    Roles = new List<string> { "apiAccess" }
                },
                ConfigurationManager.AppSettings["DominioJwt"],
                ConfigurationManager.AppSettings["SecretoJwt"],
                TimeSpan.FromHours(1));

            HttpClient client = new HttpClient();

            // Esto no es realmente necesario incluirlo pero lo dejo como referencia
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Se incluye el token en el header de la petición
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage respuesta = await client.GetAsync("https://localhost:44342/api/Values");

            if (!respuesta.IsSuccessStatusCode)
            {
                return BadRequest();
            }

            // Al estar redireccionándolo, sólo que con la autenticacón incluida, se utiliza ResponseMessage
            return ResponseMessage(respuesta);
        }
    }
}
