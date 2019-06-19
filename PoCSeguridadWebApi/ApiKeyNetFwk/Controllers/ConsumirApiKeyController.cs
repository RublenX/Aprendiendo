using ApiKeyNetFwk.Seguridad;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApiKeyNetFwk.Controllers
{
    public class ConsumirApiKeyController : ApiController
    {
        public async Task<IHttpActionResult> Get()
        {
            HttpClient client = new HttpClient();

            // Esto no es realmente necesario incluirlo pero lo dejo como referencia
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Se incluye la ApiKey en el header de la petición
            client.DefaultRequestHeaders.Add(ApiKeyAuthMessageHandler.API_KEY, "5b7a521a-ccf5-483e-b250-447d5d5cbb81");
            HttpResponseMessage respuesta = await client.GetAsync("https://localhost:44331/api/Values");

            if (!respuesta.IsSuccessStatusCode)
            {
                return BadRequest();
            }

            // Al estar redireccionándolo, sólo que con la autenticacón incluida, se utiliza ResponseMessage
            return ResponseMessage(respuesta);
        }
    }
}
