using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.Handlers.Ovejas.Command;
using WebApiCore.Handlers.Ovejas.Query;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OvejaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OvejaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<OvejaController>
        [HttpGet]
        public async Task<IEnumerable<OvejaSummary>> GetAsync()
        {
            OvejaFilter filtroOveja = new OvejaFilter();
            return await _mediator.Send(filtroOveja);
        }

        // GET api/<OvejaController>/5
        [HttpGet("{nombreOveja}")]
        public async Task<OvejaSummary> GetAsync(string nombreOveja)
        {
            OvejaFilter filtroOveja = new OvejaFilter();
            filtroOveja.Nombre = nombreOveja;

            var ovejasDto = await _mediator.Send(filtroOveja);

            return ovejasDto.FirstOrDefault();
        }

        // POST api/<OvejaController>
        [HttpPost]
        public async Task PostAsync([FromBody] string nombreOveja)
        {
            await _mediator.Send(new OvejaSummary { Nombre = nombreOveja });
        }

        // PUT api/<OvejaController>/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] string nombreOveja)
        {
            await _mediator.Send(new OvejaSummary { Identificador = id, Nombre = nombreOveja });
        }

        // DELETE api/<OvejaController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _mediator.Send(new OvejaDelete { Identificador = id });
        }
    }
}
