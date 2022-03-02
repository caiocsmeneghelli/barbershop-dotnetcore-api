using System;
using BarberShop.Domain.Commands.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarberShop.Tests.CommandTests.Users{
    [TestClass]
    public class UpdateUserCommandTests{
        private readonly UpdateUserCommand _validCommand = new UpdateUserCommand(Guid.NewGuid(), "Lala3232");
        private readonly UpdateUserCommand _invalidCommand = new UpdateUserCommand(Guid.NewGuid(), "3232");
        public UpdateUserCommandTests()
        {
            _validCommand.Validate();
            _invalidCommand.Validate();
        }
        
        [TestMethod]
        public void Dado_um_command_valido(){
            Assert.AreEqual(_validCommand.Valid, true);
        }

        [TestMethod]
        public void Dado_um_command_invalido()
        {
            Assert.AreEqual(_invalidCommand.Valid, false);
        }
    }
}