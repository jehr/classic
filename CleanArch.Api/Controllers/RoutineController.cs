using Application.CQRS.Routine.Command;
using Application.CQRS.Routine.Exercise;
using Application.CQRS.Routine.Levels;
using Application.CQRS.Routine.Queries;
using ClaroFidelizacion.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Classic.Api.Controllers
{
    public class RoutineController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetRoutines()
        {
            return Ok(await Mediator.Send(new GetRoutinesQuery()));
        }
        [HttpGet("levels")]
        public async Task<IActionResult> GetLevels()
        {
            return Ok(await Mediator.Send(new GetLevelsQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> PostRoutines([FromBody] RoutineCommand command )
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("create-exercise")]
        public async Task<IActionResult> PostExercise([FromBody] ExerciseCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
