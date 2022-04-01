using System;
using BarberShop.Domain.Commands.Barbers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarberShop.Tests.CommandTests.Barbers{
    [TestClass]
    public class UpdateBarberCommandTests{
        private readonly UpdateBarberCommand _validCommand = new UpdateBarberCommand(Guid.NewGuid().ToString(), "Caio Cesar", "Serrano Meneghelli", "caiocsmeneghelli@outlook.com");
        private readonly UpdateBarberCommand _invalidCommand = new UpdateBarberCommand(Guid.NewGuid().ToString(), "Caio Cesar", "Serrano Meneghelli", "cai");

        private readonly ChangePasswordBarberCommand _validUpdateCommand = new ChangePasswordBarberCommand(Guid.NewGuid().ToString(), "Lala3232");
        private readonly ChangePasswordBarberCommand _invalidUpdateComamand = new ChangePasswordBarberCommand(Guid.NewGuid().ToString(), "lala");

        public UpdateBarberCommandTests()
        {
            _validCommand.Validate();
            _invalidCommand.Validate();

            _validUpdateCommand.Validate();
            _invalidUpdateComamand.Validate();
        }

        [TestMethod]
        public void Dado_um_Command_valido(){
            Assert.AreEqual(_validCommand.Valid, true);
        }

        [TestMethod]
        public void Dado_um_Command_invalido(){
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        public void Dado_um_command_Update_password_valido()
        {
            Assert.AreEqual(_validUpdateCommand.Valid, true); 
        }

        [TestMethod]
        public void Dado_um_command_Update_password_invalido()
        {
            Assert.AreEqual(_invalidUpdateComamand.Valid, false);
        }
    }
}