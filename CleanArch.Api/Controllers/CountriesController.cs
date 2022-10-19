using Application.CQRS.Location.Queries;
using ClaroFidelizacion.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Classic.Api.Controllers
{
    [Route("api/countries")]
    [ApiController]
    public class CountriesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetCountriesQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
