using System;
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

        [HttpGet]
        [Route("get-by-barber/{appointmentId}")]
        public ActionResult<IEnumerable> GetAllByBarber([FromServices]IAppointmentRepository repository, 
                                                            Guid appointmentId)
        {
            return Ok(repository.GetAllByBarber(appointmentId));
        }

        [HttpGet]
        [Route("get-by-date/{dateTime}")]
        public ActionResult<IEnumerable> GetAllByDate([FromServices]IAppointmentRepository repository, 
                                                        DateTime dateTime)
        {
            return Ok(repository.GetByDate(dateTime));
        }

        [HttpGet]
        [Route("get-all-today")]
        public ActionResult<IEnumerable> GetAllToday([FromServices]IAppointmentRepository repository)
        {
            return Ok(repository.GetAllToday());
        }

        [HttpPut]
        [Route("update-barber")]
        public ActionResult<GenericCommandResult> UpdateBarber([FromServices]AppointmentHandler handler,
                                                                    [FromBody]UpdateBarberAppointmentCommand command)
        {
            var result = (GenericCommandResult)handler.Handle(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("update-date")]
        public ActionResult<GenericCommandResult> UpdateDate([FromServices]AppointmentHandler handler,
                                                                [FromBody]UpdateDateTimeAppointmentCommand command)
        {
            var result = (GenericCommandResult)handler.Handle(command);
            return Ok(result);
        }
    }
}