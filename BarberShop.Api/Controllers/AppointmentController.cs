using System.Collections;
using BarberShop.Domain.Commands.Appointment;
using BarberShop.Domain.Commands.Contracts;
using BarberShop.Domain.Handlers;
using BarberShop.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Api.Controllers
{
    [ApiController]
    [Route("v1/appointments")]
    public class AppointmentController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable> GetAll([FromServices]IAppointmentRepository repository)
        {
            return Ok(repository.GetAll());
        }

        [HttpPost]
        [Route("")]
        public ActionResult<GenericCommandResult> Create([FromServices]AppointmentHandler handler,
                                                            [FromBody]CreateAppointmentCommand command)
        {
            var result = (GenericCommandResult)handler.Handle(command);
            return Ok(result);
        }                                                            
    }
}