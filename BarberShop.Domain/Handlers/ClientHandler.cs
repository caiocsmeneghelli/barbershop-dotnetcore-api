using BarberShop.Domain.Commands;
using BarberShop.Domain.Commands.Contracts;
using BarberShop.Domain.Handlers.Contracts;
using BarberShop.Domain.Models;
using Flunt.Notifications;

namespace BarberShop.Domain.Handlers{
    public class ClientHandler : Notifiable, IHandler<SaveClientCommand>
    {
        private readonly IClientRepository _repository;
        public ClientHandler(IClientRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(SaveClientCommand command)
        {
            command.Validate();
            if(command.Invalid)
                new GenericCommandResult(false, "Ops, something went wrong.", command.Notifications);
            
            var client = new Client(command.FirstName, command.LastName, command.Number);

            _repository.Create(client);

            return new GenericCommandResult(true, "Client has been saved.", client);
        }
    }
}