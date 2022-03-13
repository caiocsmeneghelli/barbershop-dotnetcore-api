using System.Collections.Generic;
using BarberShop.Domain.Commands.Contracts;
using BarberShop.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Api.Controllers
{
    [ApiController]
    [Route("v1/barber")]
    public class BarberController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<Barber>> GetAll()
        {
            return Ok();
        }

        [HttpPost]
        [Route("")]
        public ActionResult<GenericCommandResult> Create()
        {
            var barber = new GenericCommandResult();
            return Ok(barber);
        }
    }
}