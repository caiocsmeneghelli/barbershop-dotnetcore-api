using BarberShop.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarberShop.Tests.CommandTests.Barbers{
    [TestClass]
    public class UpdateBarberCommandTests{
        private readonly UpdateBarberCommand _validCommand = new UpdateBarberCommand("Caio Cesar", "Serrano Meneghelli", "caiocsmeneghelli@outlook.com");
        private readonly UpdateBarberCommand _invalidCommand = new UpdateBarberCommand("Caio Cesar", "Serrano Meneghelli", "cai");

        public UpdateBarberCommandTests()
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