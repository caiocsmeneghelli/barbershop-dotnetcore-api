using System;
using System.Collections.Generic;
using BarberShop.Domain.Commands.Contracts;
using BarberShop.Domain.Commands.Users;
using BarberShop.Domain.Handlers;
using BarberShop.Domain.Models;
using BarberShop.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Api.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<User>> GetAll([FromServices] IUserRepository repository)
        {
            return Ok(repository.GetAll());
        }

        [HttpPost]
        [Route("")]
        public ActionResult<GenericCommandResult> Create([FromServices] UserHandler handler,
                                                        [FromBody] CreateUserCommand command)
        {
            try
            {
                var result = handler.Handle(command);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPut]
        [Route("")]
        public ActionResult<GenericCommandResult> UpdatePassword([FromServices] UserHandler handler,
                                                                    [FromServices] IUserRepository repository,
                                                                    [FromBody] UpdateUserCommand command)
        {
            var user = repository.FindById(command.Id);
            if (user is null)
                return NotFound();
            var retorno = (GenericCommandResult)handler.Handle(command);
            if(!retorno.Success)
                return BadRequest(retorno);
            return Ok(retorno);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<User> Delete(Guid id, [FromServices] IUserRepository repository)
        {
            var user = repository.FindById(id);
            if (user is null)
                return NotFound();
            repository.Delete(id);
            return Ok(user);
        }
    }
}