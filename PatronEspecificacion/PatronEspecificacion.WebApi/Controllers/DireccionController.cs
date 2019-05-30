using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatronEspecificacion.Dominio.Entidades;
using PatronEspecificacion.Dominio.Servicios.Interfaces;
using PatronEspecificacion.Dominio.Servicios.IoC;

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
            return Ok(direcciones);
        }
        #endregion
    }
}