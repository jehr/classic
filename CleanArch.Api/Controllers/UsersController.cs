using Application.CQRS.User.Commands;
using Application.User.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClaroFidelizacion.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UsersController : ApiControllerBase
    {
        /// <summary>
        /// Método que permite Obtener todos los usuarios. 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUser([FromQuery] GetUserQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        /// <summary>
        /// Método que permite crear un nuevo usuario
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]      
        public async Task<IActionResult> PostUser([FromBody] PostUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
               
        /// <summary>
        /// Método que permite obtener un usuario para editarlo.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, PutUserCommand command)
        {
            if(id != command.Id) return BadRequest();

            command.Id = id;            

            return Ok(await Mediator.Send(command));
        }
        /// <summary>
        /// Método que elimina un usuario.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteUserCommand() { Id = id }));
        }

        /// <summary>
        /// Método para cambiar el estado a 1 al usuario.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/activate")]
        public async Task<IActionResult> StatusActivateUserById(Guid id)
        {
            return Ok(await Mediator.Send(new PutStatusActivateUserById() { Id = id }));
        }

        /// <summary>
        /// Método para cambiar el estado a 0  al usuario.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/deactivate")]
        public async Task<IActionResult> StatusDeactivateUserById(Guid id)
        {
            return Ok(await Mediator.Send(new PutStatusDeactivateUserById() { Id = id }));
        }       
    }
}
