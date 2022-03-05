using System.Collections.Generic;
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
        public IEnumerable<Client> GetAll([FromServices]IClientRepository repository)
        {
            return repository.GetAll();
        }

        [HttpPost]
        [Route("")]
        public GenericCommandResult Create([FromServices] ClientHandler handler,
                                            [FromBody]CreateClientCommand command)
        {
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}