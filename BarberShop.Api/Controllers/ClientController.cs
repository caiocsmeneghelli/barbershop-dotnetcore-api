using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarberShop.Domain.Commands.Clients;
using BarberShop.Domain.Commands.Contracts;
using BarberShop.Domain.Handlers;
using BarberShop.Domain.Models;
using BarberShop.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Api.Controllers
{
    [ApiController]
    [Route("v1/clients")]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<Client>> GetAll([FromServices]IClientRepository repository)
        {
            return Ok(repository.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Client> GetById(Guid id,[FromServices]IClientRepository repository)
        {
            var client = repository.FindByIdAsNoTracking(id);
            if(client is null)
                return NotFound();
            return Ok(client);
        }

        [HttpGet]
        [Route("getbyname/{name}")]
        public ActionResult<IEnumerable<Client>> GetByName(string name, [FromServices]IClientRepository repository)
        {
            var result = repository.GetByName(name);
            if(result.Count() == 0)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public ActionResult<GenericCommandResult> Create([FromServices] ClientHandler handler,
                                            [FromBody]CreateClientCommand command)
        {
            var response = (GenericCommandResult)handler.Handle(command);
            if(!response.Success) 
                return BadRequest(response);
            return Ok(response);
        }

        [HttpPut]
        [Route("")]
        public ActionResult<GenericCommandResult> Update([FromBody] UpdateClientCommand command,
                                                        [FromServices] ClientHandler handler)
        {
            var response = (GenericCommandResult)handler.Handle(command);
            if(!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete([FromServices]IClientRepository repository, Guid id)
        {
            var client = repository.FindById(id);
            if(client is null)
                return NotFound();
            repository.Delete(id);
            return Ok(client);
        }
    }
}