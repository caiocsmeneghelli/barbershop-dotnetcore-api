using System;
using BarberShop.Domain.Commands.Barbers;
using BarberShop.Domain.Commands.Contracts;
using BarberShop.Domain.Handlers;
using BarberShop.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarberShop.Tests.HandlerTests.Barbers
{
    [TestClass]
    public class BarberHandlerTest
    {
        private readonly CreateBarberCommand _validCreateBarberCommand =
            new CreateBarberCommand("Caio Cesar", "Serrano Meneghelli",
            "caiocsmeneghelli@gmail.com");
        private readonly CreateBarberCommand _invalidCreateBarberCommand =
            new CreateBarberCommand("Caio Cesar", "Serrano Meneghelli",
            "caio");
        private readonly UpdateBarberCommand _invalidUpdateBarberCommand =
            new UpdateBarberCommand(Guid.NewGuid().ToString(), "Caio Cesar", "Meneghelli", "caioc");
        private readonly UpdateBarberCommand _validUpdateBarberCommand =
            new UpdateBarberCommand(Guid.NewGuid().ToString(), "Caio Cesar", "Meneghelli", "caiocsmeneghelli@gmail.com");
        private readonly BarberHandler handler = new BarberHandler(new FakeBarberRepository());

        [TestMethod]
        public void Dado_create_barber_command_valido()
        {
            var retorno = (GenericCommandResult)handler.Handle(_validCreateBarberCommand);
            Assert.AreEqual(retorno.Success, true);
        }

        [TestMethod]
        public void Dado_create_barber_command_invalido()
        {
            var retorno = (GenericCommandResult)handler.Handle(_invalidCreateBarberCommand);
            Assert.AreEqual(retorno.Success, false);
        }

        [TestMethod]
        public void Dado_um_update_barber_command_valido()
        {
            var retorno = (GenericCommandResult)handler.Handle(_validUpdateBarberCommand);
            Assert.AreEqual(retorno.Success, true);
        }

        [TestMethod]
        public void Dado_um_update_barber_command_invalido()
        {
            var retorno = (GenericCommandResult)handler.Handle(_invalidUpdateBarberCommand);
            Assert.AreEqual(retorno.Success, false);
        }
    }
}