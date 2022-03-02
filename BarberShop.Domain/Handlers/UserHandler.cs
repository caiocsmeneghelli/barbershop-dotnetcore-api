using BarberShop.Domain.Commands.Contracts;
using BarberShop.Domain.Commands.Users;
using BarberShop.Domain.Handlers.Contracts;
using BarberShop.Domain.Models;
using BarberShop.Domain.Repositories;
using Flunt.Notifications;

namespace BarberShop.Domain.Handlers
{
    public class UserHandler : Notifiable,
                                IHandler<CreateUserCommand>,
                                IHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _repository;
        public UserHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(UpdateUserCommand command)
        {
            command.Validate();
            if(command.Invalid)
                return new GenericCommandResult(false, "Ops, Something went wrong.", command.Notifications);

            var user = _repository.FindById(command.Id);

            user.ChangePassword(command.Password);
            _repository.Update(user);

            return new GenericCommandResult(true, "User password has been updated.", user);
        }

        public ICommandResult Handle(CreateUserCommand command)
        {
            command.Validate();
            if(command.Invalid)
                return new GenericCommandResult(false, "Ops, Something went wrong.", command.Notifications);

            var user = new User(command.UserName, command.Password, command.Role);
            _repository.Create(user);

            return new GenericCommandResult(true, "User has been created.", user);
        }
    }
}