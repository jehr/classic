using Application.CQRS.Location.Queries;
using ClaroFidelizacion.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Classic.Api.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CitiesController : ApiControllerBase
    {
        [HttpGet("{id}/by-state")]
        public async Task<IActionResult> GetCityByStateId(Guid id)
        {
            return Ok(await Mediator.Send(new GetCityByStateIdQuery() { Id = id }));

        }
    }
}
