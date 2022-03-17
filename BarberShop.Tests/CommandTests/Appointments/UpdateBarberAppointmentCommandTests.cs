using System;
using BarberShop.Domain.Commands.Appointment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarberShop.Tests.CommandTests.Appointments
{
    [TestClass]
    public class UpdateBarberAppointmentCommandTests
    {
        private readonly UpdateBarberAppointmentCommand _validCommand
            = new UpdateBarberAppointmentCommand(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
        private readonly UpdateBarberAppointmentCommand _invalidCommand
            = new UpdateBarberAppointmentCommand("", Guid.NewGuid().ToString());
        
        public UpdateBarberAppointmentCommandTests()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        [TestMethod]
        public void Dado_um_Command_invalido()
        {
            Assert.AreEqual(false, _invalidCommand.Valid);
        }

        [TestMethod]
        public void Dado_um_command_valido()
        {
            Assert.AreEqual(true, _validCommand.Valid);
        }
    }
}