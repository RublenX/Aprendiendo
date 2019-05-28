using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatronEspecificacion.Dominio.Entidades;
using PatronEspecificacion.Dominio.Servicios.Interfaces;

namespace PatronEspecificacion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DireccionController : ControllerBase
    {
        #region Ciclo de Vida
        internal IGestorDirecciones gestorDirecciones;

        public DireccionController(IGestorDirecciones gestor)
        {
            gestorDirecciones = gestor;
        }
        #endregion

        #region Exposición de métodos
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var direcciones = await Task.Run(() => gestorDirecciones.ObtenerDirecciones());
            var direccion0 = direcciones.First();
            DireccionEspanolaEntity direccion1 = new DireccionEspanolaEntity
            {
                Id = 1,
                Provincia = "Madrid",
                Municipio = "Madrid",
                Calle = "Paseo de la Castellana"
            };
            var direccion2 = direcciones.First().Clone() as DireccionEspanolaEntity;
            direccion2.Calle += " XXX";
            try
            {
                if (direccion1 == direccion0)
                {
                    Console.WriteLine("Comparación realizada con éxito");
                }
            }
            catch (Exception ex)
            {
                string parada = ex.Message;
            }
            return Ok(direcciones);
        }
        #endregion
    }
}