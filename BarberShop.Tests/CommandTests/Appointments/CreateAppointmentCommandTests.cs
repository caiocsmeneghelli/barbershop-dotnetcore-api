using System;
using BarberShop.Domain.Commands.Appointment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarberShop.Tests.CommandTests.Appointments
{
    [TestClass]
    public class CreateAppointmentCommandTests
    {
        private readonly CreateAppointmentCommand _validCommand = 
            new CreateAppointmentCommand(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), DateTime.Now);
        private readonly CreateAppointmentCommand _invalidCommand = 
            new CreateAppointmentCommand("", "", DateTime.Now);
        public CreateAppointmentCommandTests()
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
        public void Dado_um_command_valid()
        {
            Assert.AreEqual(true, _validCommand.Valid);
        }
    }
}