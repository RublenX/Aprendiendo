using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WinFrmReferenciaExterna
{
    /// <summary>
    /// Respuesta a la pregunta https://es.stackoverflow.com/questions/271610/consumir-servicio-post-c-web-form
    /// </summary>
    public class ConsumirPost
    {
        public async Task<string> Lanzar(object obj)
        {
            try
            {
                HttpClient client = new HttpClient()
                {
                    BaseAddress = new Uri("http://localhost:62221/"),
                };
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respuesta = client.PostAsJsonAsync("/api/Values", obj).Result;
                if (respuesta.StatusCode == HttpStatusCode.OK)
                {
                    // La respuesta es correcta y por ejemplo la retorno como string
                    return await respuesta.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR : {ex.Message}");
            }

            return "KO";
        }
    }
}
