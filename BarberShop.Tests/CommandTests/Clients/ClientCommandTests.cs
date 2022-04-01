using BarberShop.Domain.Commands.Clients;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarberShop.Tests.CommandTests.Clients{
    [TestClass]
    public class ClientCommandTests{
        private readonly CreateClientCommand _createValidCommand = new CreateClientCommand("Caio Cesar", "Serrano Meneghelli", "27999096912");
        private readonly CreateClientCommand _createInvalidCommand = new CreateClientCommand("Caio Cesar", "Serrano Meneghelli", "2799909691222");

        private readonly UpdateClientCommand _updateValidCommand = new UpdateClientCommand(System.Guid.NewGuid().ToString(), "Caio Cesar", "Serrano Meneghelli", "27999096912");
        private readonly UpdateClientCommand _updateInvalidCommand = new UpdateClientCommand(System.Guid.Empty.ToString(), "Caio Cesar", "Serrano Meneghelli", "2799909691222");

        public ClientCommandTests()
        {
            _createValidCommand.Validate();
            _createInvalidCommand.Validate();

            _updateValidCommand.Validate();
            _updateInvalidCommand.Validate();
        }

        [TestMethod]
        public void Dado_um_Command_valido_para_criacao_de_novo_client(){
            Assert.AreEqual(_createValidCommand.Valid, true);
        }

        [TestMethod]
        public void Dado_um_Command_invalido_para_criacao_de_um_novo_(){
            Assert.AreEqual(_createInvalidCommand.Valid, false);
        }

        [TestMethod]
        public void Dado_um_command_valido_para_atualizacao(){
            Assert.AreEqual(_updateValidCommand.Valid, true);
        }

        [TestMethod]
        public void Dado_um_command_invalido_para_atualizacao(){
            Assert.AreEqual(_updateInvalidCommand.Valid, false);
        }
    }
}