using System;
using BarberShop.Domain.Commands.Contracts;
using BarberShop.Domain.Commands.Users;
using BarberShop.Domain.Handlers;
using BarberShop.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarberShop.Tests.HandlerTests.Users
{
    [TestClass]
    public class UserHandlerTests
    {
        private readonly UserHandler handler = new UserHandler(new FakeUserRepository());
        private readonly CreateUserCommand _validCreateCommand 
            = new CreateUserCommand("caiocsmeneghelli@gmail.com", "Lala3232");
        private readonly CreateUserCommand _invalidCreateCommnad
            = new CreateUserCommand("caiocsmeneghelli@gmail.com", "lala");
        
        private readonly UpdateUserCommand _validUpdateCommand
            = new UpdateUserCommand(Guid.NewGuid(), "lala3232");
        private readonly UpdateUserCommand _invalidUpdateCommand
            = new UpdateUserCommand(Guid.NewGuid(), "lala");

        [TestMethod]
        public void Dado_um_create_user_command_valido()
        {
            var retorno = (GenericCommandResult)handler.Handle(_validCreateCommand);
            Assert.AreEqual(retorno.Success, true);
        }

        [TestMethod]
        public void Dado_um_create_user_command_invalido()
        {
            var retorno = (GenericCommandResult)handler.Handle(_invalidCreateCommnad);
            Assert.AreEqual(retorno.Success, false);
        }

        [TestMethod]
        public void Dado_um_update_user_command_valido()
        {
            var retorno = (GenericCommandResult)handler.Handle(_validUpdateCommand);
            Assert.AreEqual(retorno.Success, true);
        }

        [TestMethod]
        public void Dado_um_update_user_command_invalido()
        {
            var retorno = (GenericCommandResult)handler.Handle(_invalidCreateCommnad);
            Assert.AreEqual(retorno.Success, false);
        }
    }
}