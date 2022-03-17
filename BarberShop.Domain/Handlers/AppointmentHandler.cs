using BarberShop.Domain.Commands.Contracts;
using BarberShop.Domain.Commands.Appointment;
using BarberShop.Domain.Handlers.Contracts;
using BarberShop.Domain.Models;
using BarberShop.Domain.Repositories;
using Flunt.Notifications;

namespace BarberShop.Domain.Handlers
{
    public class AppointmentHandler : Notifiable,
                                    IHandler<CreateAppointmentCommand>,
                                    IHandler<UpdateBarberAppointmentCommand>,
                                    IHandler<UpdateDateTimeAppointmentCommand>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IBarberRepository _barberRepository;

        public AppointmentHandler(IAppointmentRepository appointmentRepository,
                                IClientRepository clientRepository,
                                IBarberRepository barberRepository)
        {
            _appointmentRepository = appointmentRepository;
            _clientRepository = clientRepository;
            _barberRepository = barberRepository;
        }

        public ICommandResult Handle(UpdateDateTimeAppointmentCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, something went wrong.", command.Notifications);

            var appointment = _appointmentRepository.FindById(command.IdAppointment);
            if (appointment is null)
                return new GenericCommandResult(false, "Appointment not found.", command.IdAppointment);

            appointment.ChangeDate(command.DateTime);
            _appointmentRepository.Update(appointment);

            return new GenericCommandResult(true, "Appointment has been updated.", appointment);
        }

        public ICommandResult Handle(UpdateBarberAppointmentCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, something went wrong.", command.Notifications);

            var barber = _barberRepository.FindById(command.IdBarber);
            if (barber is null)
                return new GenericCommandResult(false, "Barber not found.", command.IdBarber);

            var appointment = _appointmentRepository.FindById(command.IdAppointment);
            if (appointment is null)
                return new GenericCommandResult(false, "Appointment not found.", command.IdAppointment);

            appointment.ChangeBarber(barber);
            _appointmentRepository.Update(appointment);

            return new GenericCommandResult(true, "Appointment has been updated.", appointment);
        }

        public ICommandResult Handle(CreateAppointmentCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, something went wrong.", command.Notifications);

            var barber = _barberRepository.FindById(command.IdBarber);
            if (barber is null)
                return new GenericCommandResult(false, "Barber not found.", command.IdBarber);

            var client = _clientRepository.FindById(command.IdClient);
            if (client is null)
                return new GenericCommandResult(false, "Client not found.", command.IdClient);

            var appointment = new Appointment(command.DateTime, barber, client);
            _appointmentRepository.Create(appointment);

            return new GenericCommandResult(true, "New appointment has been created.", appointment);
        }
    }
}