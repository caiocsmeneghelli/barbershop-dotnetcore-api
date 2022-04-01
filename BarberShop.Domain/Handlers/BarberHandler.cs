using System;
using BarberShop.Domain.Commands.Barbers;
using BarberShop.Domain.Commands.Contracts;
using BarberShop.Domain.Handlers.Contracts;
using BarberShop.Domain.Models;
using BarberShop.Domain.Repositories;
using Flunt.Notifications;

namespace BarberShop.Domain.Handlers
{
    public class BarberHandler : Notifiable,
                                    IHandler<CreateBarberCommand>,
                                    IHandler<UpdateBarberCommand>,
                                    IHandler<ChangePasswordBarberCommand>
    {
        private readonly IBarberRepository _repository;
        public BarberHandler(IBarberRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateBarberCommand command)
        {
            command.Validate();
            if(command.Invalid)
                return new GenericCommandResult(false, "Ops, something went wrong.", command.Notifications);
            
            var barber = new Barber(command.FirstName, command.LastName, command.Email,
                                         command.UserName, command.Password);
            _repository.Create(barber);

            return new GenericCommandResult(true, "Barber has been created.", barber);
        }

        public ICommandResult Handle(UpdateBarberCommand command)
        {
            command.Validate();
            if(command.Invalid)
                return new GenericCommandResult(false, "Ops, something went wrong.", command.Notifications);

            var barber = _repository.FindById(Guid.Parse(command.Id));
            if(barber is null)
                return new GenericCommandResult(false, "Ops, barber not found.", command);

            barber.UpdateEmail(command.Email);
            barber.UpdateName(command.FirstName, command.LastName);

            _repository.Update(barber);

            return new GenericCommandResult(true, "Barber has been updated.", barber);
        }

        public ICommandResult Handle(ChangePasswordBarberCommand command)
        {
            command.Validate();
            if(command.Invalid)
                return new GenericCommandResult(false, "Ops, something went wrong.", command.Notifications);

            var barber = _repository.FindById(Guid.Parse(command.Id));

            barber.ChangePassword(command.Password);
            
            _repository.Update(barber);

            return new GenericCommandResult(true, "Barber password has been updated.", barber);
        }
    }
}