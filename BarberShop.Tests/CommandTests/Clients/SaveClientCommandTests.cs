using BarberShop.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarberShop.Tests.CommandTests.Clients{
    [TestClass]
    public class SaveClientCommandTests{
        private readonly CreateClientCommand _validCommand = new CreateClientCommand("Caio Cesar", "Serrano Meneghelli", "27999096912");
        private readonly CreateClientCommand _invalidCommand = new CreateClientCommand("Caio Cesar", "Serrano Meneghelli", "2799909691222");

        public SaveClientCommandTests()
        {
            _validCommand.Validate();
            _invalidCommand.Validate();
        }

        [TestMethod]
        public void Dado_um_Command_valido(){
            Assert.AreEqual(_validCommand.Valid, true);
        }

        [TestMethod]
        public void Dado_um_Command_invalido(){
            Assert.AreEqual(_invalidCommand.Valid, false);
        }
    }
}