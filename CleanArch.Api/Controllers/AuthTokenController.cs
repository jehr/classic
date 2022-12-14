using Application.Auth.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ClaroFidelizacion.Api.Controllers
{
    [Route("api/auth-token")]
    [ApiController]
    public class AuthTokenController : ApiControllerBase
    {

        private readonly ILogger<AuthTokenController> _logger;

        public AuthTokenController(ILogger<AuthTokenController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public async Task<IActionResult> Authentication([FromBody] PostLoginCommand command)
        {

            return Ok(await Mediator.Send(command));
        }



    }
}
