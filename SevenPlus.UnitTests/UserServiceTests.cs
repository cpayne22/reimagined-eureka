using Microsoft.VisualStudio.TestTools.UnitTesting;
using SevenPlus.Services;
using SevenPlus.UnitTests.Mocks;
using System.Linq;

namespace SevenPlus.UnitTests
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        public void UserGetByID()
        {
            IUserRepository repo = new MockRepository();
            var service = new UserService(repo);
            var response = service.UserGet(1);
            Assert.AreEqual(true, response.Result.IsValid);
            Assert.AreEqual(20, response.Result.ReturnValue.age);
        }

        [TestMethod]
        public void UsersByAge()
        {
            IUserRepository repo = new MockRepository();
            var service = new UserService(repo);
            var response = service.UsersGet();
            Assert.AreEqual(true, response.Result.IsValid);
            Assert.AreEqual(5, response.Result.ReturnValue.Count());
        }

        [TestMethod]
        public void RepoBadHost()
        {
            IUserRepository repo = new MockRepository();
            var service = new UserService(repo);
            var response = service.UsersGet();
            Assert.AreEqual(true, response.Result.IsValid);
            Assert.AreEqual(5, response.Result.ReturnValue.Count());
        }
    }
}
