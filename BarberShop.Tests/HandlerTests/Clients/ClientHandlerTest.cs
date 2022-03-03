using System;
using BarberShop.Domain.Commands.Clients;
using BarberShop.Domain.Commands.Contracts;
using BarberShop.Domain.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarberShop.Tests.HandlerTests.Clients
{
    [TestClass]
    public class ClientHandlerTest
    {
        private readonly ClientHandler handler = new ClientHandler(new FakeClientRepository());
        private readonly CreateClientCommand _validCreateClientCommand = 
            new CreateClientCommand("Caio Cesar", "Meneghelli", "27999096912");
        private readonly UpdateClientCommand _validUpdateClientCommand =
            new UpdateClientCommand(Guid.NewGuid(), "Caio Cesar", "Menneghelli", "27999096912");
        
        [TestMethod]
        public void Criar_um_client_valido()
        {
            var retorno = (GenericCommandResult)handler.Handle(_validCreateClientCommand);
            Assert.AreEqual(retorno.Success, true);
        }

        [TestMethod]
        public void Update_um_client_valido()
        {
            var retorno = (GenericCommandResult)handler.Handle(_validUpdateClientCommand);
            Assert.AreEqual(retorno.Success, true);
        }
        
    }
}