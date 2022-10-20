using Application.CQRS.Payment;
using ClaroFidelizacion.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classic.Api.Controllers
{
    public class PaymentController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostRol([FromBody] PostPaymentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
