using System;
using BarberShop.Domain.Commands.Appointment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarberShop.Tests.CommandTests.Appointments
{
    [TestClass]
    public class UpdateDateTimeAppointmentCommandTests
    {
        private readonly UpdateDateTimeAppointmentCommand _validCommand
            = new UpdateDateTimeAppointmentCommand(Guid.NewGuid().ToString(), DateTime.Now);
        private readonly UpdateDateTimeAppointmentCommand _invalidCommand
            = new UpdateDateTimeAppointmentCommand("", DateTime.Now);
        
        public UpdateDateTimeAppointmentCommandTests()
        {
            _validCommand.Validate();
            _invalidCommand.Validate();
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