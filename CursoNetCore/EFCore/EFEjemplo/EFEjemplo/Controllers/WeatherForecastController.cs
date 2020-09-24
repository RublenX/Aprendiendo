using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFEjemplo.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EFEjemplo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ICancionService _cancionService;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICancionService cancionService)
        {
            _logger = logger;
            _cancionService = cancionService;
        }

        //public IEnumerable<WeatherForecast> Get()
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> GetAsync()
        {
            //_cancionService.AddCancion(new Models.Cancion
            //{
            //    Descripcion = "America",
            //    Duracion = new TimeSpan(0, 4, 25),
            //    Titulo = "America"
            //});

            await _cancionService.AddCancionAsync(new Models.Cancion
            {
                Descripcion = "Un beso y una flor",
                Duracion = new TimeSpan(0, 3, 55),
                Titulo = "Un beso y una flor"
            });

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
