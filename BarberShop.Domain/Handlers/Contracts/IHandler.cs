using BarberShop.Domain.Commands.Contracts;

namespace BarberShop.Domain.Handlers.Contracts{
    public interface IHandler<T> where T : ICommand{
        ICommandResult Handle(T command);
    }
}