using Application.CQRS.Routine.GroupsMuscular;
using ClaroFidelizacion.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Classic.Api.Controllers
{
    public class GroupMuscular : ApiControllerBase
    {
        [HttpGet("group-muscular")]
        public async Task<IActionResult> GetGroupsMuscular()
        {
            return Ok(await Mediator.Send(new GetGroupsMuscularQuery()));
        }
    }
}
