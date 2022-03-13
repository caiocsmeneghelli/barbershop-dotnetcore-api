using System;
using System.Collections.Generic;
using BarberShop.Domain.Commands.Barbers;
using BarberShop.Domain.Commands.Contracts;
using BarberShop.Domain.Handlers;
using BarberShop.Domain.Models;
using BarberShop.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Api.Controllers
{
    [ApiController]
    [Route("v1/barber")]
    public class BarberController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<Barber>> GetAll([FromServices] IBarberRepository repository)
        {
            var barbers = repository.GetAll();
            return Ok(barbers);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Barber> Get(Guid id, [FromServices] IBarberRepository repository)
        {
            var barber = repository.FindById(id);
            if (barber is null)
                return NotFound();
            return Ok(barber);
        }

        [HttpPost]
        [Route("")]
        public ActionResult<GenericCommandResult> Create([FromBody] CreateBarberCommand command,
                                                            [FromServices] BarberHandler handler)
        {
            var result = (GenericCommandResult)handler.Handle(command);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPut]
        [Route("")]
        public ActionResult<GenericCommandResult> Update([FromServices] BarberHandler handler,
                                                            [FromBody] UpdateBarberCommand command)
        {
            var result = (GenericCommandResult)handler.Handle(command);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPut]
        [Route("change-password")]
        public ActionResult<GenericCommandResult> UpdatePassword([FromBody] ChangePasswordBarberCommand command,
                                                                [FromServices] BarberHandler handler)
        { 
            var result = (GenericCommandResult)handler.Handle(command);
            if(!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete([FromServices] IBarberRepository repository, Guid id)
        {
            var barber = repository.FindById(id);
            if (barber is null)
                return NotFound();
            repository.Delete(id);
            return Ok();
        }
    }
}