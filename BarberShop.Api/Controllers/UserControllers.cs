using System.Collections.Generic;
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
        public ActionResult<IEnumerable<User>> GetAll([FromServices]IUserRepository repository)
        {
            return Ok(repository.GetAll());
        }
    }
}