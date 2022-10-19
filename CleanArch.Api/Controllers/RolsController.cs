using Application.CQRS.Rol.Commands;
using Application.Rol.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClaroFidelizacion.Api.Controllers
{
    [Route("api/rols")]
    [ApiController]
    [Authorize]
    public class RolsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetRol([FromQuery] GetRolQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> PostRol([FromBody] PostRolCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRol(Guid id, PutRolCommand command)
        {
            if (id != command.Id) return BadRequest();
            

            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteRolCommand() { Id = id }));
        }

        [HttpGet("{id}/activate")]
        public async Task<IActionResult> StatusActivateRolById(Guid id)
        {
            return Ok(await Mediator.Send(new PutStatusActivateRolById() { Id = id }));
        }

        [HttpGet("{id}/deactivate")]
        public async Task<IActionResult> StatusDeactivateRolById(Guid id)
        {
            return Ok(await Mediator.Send(new PutStatusDeactivateRolById() { Id = id }));
        }
    }
}
