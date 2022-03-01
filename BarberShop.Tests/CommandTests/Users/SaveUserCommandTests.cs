using BarberShop.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarberShop.Tests.CommandTests.Users{
    [TestClass]
    public class SaveUserCommandTests{
        private readonly SaveUserCommand _validCommand = new SaveUserCommand("t_cmeneghelli", "Lala3232");
        private readonly SaveUserCommand _invalidCommand = new SaveUserCommand("t_cmeneghelli", "3232");
        public SaveUserCommandTests()
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