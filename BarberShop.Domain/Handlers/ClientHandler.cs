using BarberShop.Domain.Commands.Clients;
using BarberShop.Domain.Commands.Contracts;
using BarberShop.Domain.Handlers.Contracts;
using BarberShop.Domain.Models;
using BarberShop.Domain.Repositories;
using Flunt.Notifications;

namespace BarberShop.Domain.Handlers{
    public class ClientHandler : Notifiable,
                                 IHandler<CreateClientCommand>,
                                 IHandler<UpdateClientCommand>
    {
        private readonly IClientRepository _repository;
        public ClientHandler(IClientRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateClientCommand command)
        {
            command.Validate();
            if(command.Invalid)
                return new GenericCommandResult(false, "Ops, something went wrong.", command.Notifications);
            
            var client = new Client(command.FirstName, command.LastName, command.Number);

            _repository.Create(client);

            return new GenericCommandResult(true, "Client has been created.", client);
        }

        public ICommandResult Handle(UpdateClientCommand command)
        {
            command.Validate();
            if(command.Invalid)
               return  new GenericCommandResult(false, "Ops, something went wrong.", command.Notifications);

            var client = _repository.FindById(command.Id);
            if(client is null)
                return new GenericCommandResult(false, "Client not found.", command);
            
            client.ChangePhoneNumber(command.Number);
            
            _repository.Update(client);

            return new GenericCommandResult(true, "Client has been updated.", client);
        }
    }
}