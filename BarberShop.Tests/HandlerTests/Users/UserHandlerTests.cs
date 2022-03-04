using BarberShop.Domain.Handlers;
using BarberShop.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarberShop.Tests.HandlerTests.Users
{
    [TestClass]
    public class UserHandlerTests
    {
        private readonly UserHandler handler = new UserHandler(new FakeUserRepository());
    }
}