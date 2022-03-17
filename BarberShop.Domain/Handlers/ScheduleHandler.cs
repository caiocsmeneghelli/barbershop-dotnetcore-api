using BarberShop.Domain.Commands.Contracts;
using BarberShop.Domain.Commands.Schedule;
using BarberShop.Domain.Handlers.Contracts;
using BarberShop.Domain.Models;
using BarberShop.Domain.Repositories;
using Flunt.Notifications;

namespace BarberShop.Domain.Handlers
{
    public class ScheduleHandler : Notifiable,
                                    IHandler<CreateScheduleCommand>,
                                    IHandler<UpdateBarberScheduleCommand>,
                                    IHandler<UpdateDateTimeScheduleCommand>
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IBarberRepository _barberRepository;

        public ScheduleHandler(IScheduleRepository scheduleRepository, IClientRepository clientRepository, IBarberRepository barberRepository)
        {
            _scheduleRepository = scheduleRepository;
            _clientRepository = clientRepository;
            _barberRepository = barberRepository;
        }

        public ICommandResult Handle(UpdateDateTimeScheduleCommand command)
        {
            command.Validate();
            if(command.Invalid)
                return new GenericCommandResult(false, "Ops, something went wrong.", command.Notifications);
            
            var schedule = _scheduleRepository.FindById(command.IdSchedule);
            if(schedule is null)
                return new GenericCommandResult(false, "Schedule not found.", command.IdSchedule);
            
            schedule.ChangeDate(command.DateTime);
            _scheduleRepository.Update(schedule);

            return new GenericCommandResult(true, "Schedule has been updated.", schedule);
        }

        public ICommandResult Handle(UpdateBarberScheduleCommand command)
        {
            command.Validate();
             if(command.Invalid)
                return new GenericCommandResult(false, "Ops, something went wrong.", command.Notifications);
            
            var barber = _barberRepository.FindById(command.IdBarber);
            if(barber is null)
                return new GenericCommandResult(false, "Barber not found.", command.IdBarber);
            
            var schedule = _scheduleRepository.FindById(command.IdSchedule);
            if(schedule is null)
                return new GenericCommandResult(false, "Schedule not found.", command.IdSchedule);
            
            schedule.ChangeBarber(barber);
            _scheduleRepository.Update(schedule);

            return new GenericCommandResult(true, "Schedule has been updated.", schedule);
        }

        public ICommandResult Handle(CreateScheduleCommand command)
        {
            command.Validate();
            if(command.Invalid)
                return new GenericCommandResult(false, "Ops, something went wrong.", command.Notifications);
            
            var barber = _barberRepository.FindById(command.IdBarber);
            if(barber is null)
                return new GenericCommandResult(false, "Barber not found.", command.IdBarber);
            
            var client = _clientRepository.FindById(command.IdClient);
            if(client is null)
                return new GenericCommandResult(false, "Client not found.", command.IdClient);
            
            var schedule = new Schedule(command.DateTime, barber, client);
            _scheduleRepository.Create(schedule);

            return new GenericCommandResult(true, "New schedule has been created.", schedule);
        }
    }
}