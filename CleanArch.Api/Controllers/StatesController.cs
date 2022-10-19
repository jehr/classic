using Application.CQRS.Location.Queries;
using ClaroFidelizacion.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Classic.Api.Controllers
{
    [Route("api/states")]
    [ApiController]
    public class StatesController : ApiControllerBase
    {
        [HttpGet("{id}/by-country")]
        public async Task<IActionResult> GetStateByCountryId(Guid id)
        {
            return Ok(await Mediator.Send(new GetStateByCountryIdQuery() { Id = id }));

        }
    }
}
