using BarberShop.Domain.Commands.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarberShop.Tests.CommandTests.Users{
    [TestClass]
    public class CreateUserCommandTests{
        private readonly CreateUserCommand _validCommand = new CreateUserCommand("t_cmeneghelli", "Lala3232");
        private readonly CreateUserCommand _invalidCommand = new CreateUserCommand("t_cmeneghelli", "3232");
        public CreateUserCommandTests()
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