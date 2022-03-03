using BarberShop.Domain.Commands.Barbers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarberShop.Tests.CommandTests.Barbers{
    [TestClass]
    public class CreateBarberCommandTests{
        private readonly CreateBarberCommand _validCommand = 
            new CreateBarberCommand("Caio Cesar", "Serrano Meneghelli", 
            "caiocsmeneghelli@gmail.com", "caiocsmeneghelli", "Password");
        private readonly CreateBarberCommand _invalidCommand = 
            new CreateBarberCommand("Caio Cesar", "Serrano Meneghelli", 
            "caiocsmeneghelli@gmail.com", "caiocsmeneghelli", "Pass"); 

        public CreateBarberCommandTests()
        {
            _validCommand.Validate();
            _invalidCommand.Validate();
        }
        [TestMethod]
        public void Dado_um_command_valido(){
            Assert.AreEqual(_validCommand.Valid, true);
        }

        [TestMethod]
        public void Dado_um_Command_invalido(){
            Assert.AreEqual(_invalidCommand.Valid, false);
        }
    } 
}