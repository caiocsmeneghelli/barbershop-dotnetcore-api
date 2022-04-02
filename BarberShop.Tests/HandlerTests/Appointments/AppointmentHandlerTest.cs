using System;
using BarberShop.Domain.Commands.Appointment;
using BarberShop.Domain.Commands.Contracts;
using BarberShop.Domain.Handlers;
using BarberShop.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarberShop.Tests.HandlerTests.Appointment
{
    [TestClass]
    public class AppointmentHandlerTest
    {
        private readonly CreateAppointmentCommand _validCreateAppointmentCommand
            = new CreateAppointmentCommand(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), DateTime.Now);
        private readonly CreateAppointmentCommand _invalidCreateAppointmentCommand
            = new CreateAppointmentCommand("", Guid.NewGuid().ToString(), DateTime.Now);
        private readonly UpdateBarberAppointmentCommand _validUpdateBarberAppointmentCommand
            = new UpdateBarberAppointmentCommand(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
        private readonly UpdateBarberAppointmentCommand _invalidUpdateBarberAppointmentCommand
            = new UpdateBarberAppointmentCommand("", Guid.NewGuid().ToString());
        private readonly UpdateDateTimeAppointmentCommand _validUpdateDateTimeCommand
            = new UpdateDateTimeAppointmentCommand(Guid.NewGuid().ToString(), DateTime.Now);
        private readonly UpdateDateTimeAppointmentCommand _invalidUpdateDateTimeCommand
            = new UpdateDateTimeAppointmentCommand("", DateTime.Now);
        
        private readonly AppointmentHandler handler = new AppointmentHandler(
            new FakeAppointmentRepository(),
            new FakeClientRepository(), 
            new FakeBarberRepository());

        [TestMethod]        
        public void Dado_um_create_appointment_valido()
        {
            var retorno = (GenericCommandResult)handler.Handle(_validCreateAppointmentCommand);
            Assert.AreEqual(retorno.Success, true);
        }

        [TestMethod]
        public void Dado_um_create_appointment_invalido()
        {
            var retorno = (GenericCommandResult)handler.Handle(_invalidCreateAppointmentCommand);
            Assert.AreEqual(retorno.Success, false);
        }

        [TestMethod]
        public void Dado_um_update_barber_appointment_command_valido()
        {
            var retorno = (GenericCommandResult)handler.Handle(_validUpdateBarberAppointmentCommand);
            Assert.AreEqual(retorno.Success, true);
        }

        [TestMethod]
        public void Dado_um_update_barber_appointment_command_invalido()
        {
            var retorno = (GenericCommandResult)handler.Handle(_invalidUpdateBarberAppointmentCommand);
            Assert.AreEqual(retorno.Success, false);
        }

        [TestMethod]
        public void Dado_um_update_datetime_command_valido()
        {
            var retorno = (GenericCommandResult)handler.Handle(_validUpdateDateTimeCommand);
            Assert.AreEqual(retorno.Success, true);
        }

        
        [TestMethod]
        public void Dado_um_update_datetime_command_invalido()
        {
            var retorno = (GenericCommandResult)handler.Handle(_invalidUpdateDateTimeCommand);
            Assert.AreEqual(retorno.Success, false);
        }

        [TestMethod]
        public void Testar_a_hora_que_sera_salva_no_create_command_valido()
        {
            var retorno = (GenericCommandResult)handler.Handle(_validCreateAppointmentCommand);
            var appointment = (BarberShop.Domain.Models.Appointment)retorno.Data;
            Assert.AreEqual(appointment.Date.Minute, 0);
        }

        [TestMethod]
        public void verificar_valor_minuto_no_update_command_date_valido()
        {
            var retorno = (GenericCommandResult)handler.Handle(_validUpdateDateTimeCommand);
            var appointment = (BarberShop.Domain.Models.Appointment)retorno.Data;
            Assert.AreEqual(appointment.Date.Minute, 0);
        }
    }
}