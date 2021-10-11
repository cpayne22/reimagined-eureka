using Microsoft.VisualStudio.TestTools.UnitTesting;
using SevenPlus.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenPlus.UnitTests
{
    [TestClass]
    public class UserRepositoryTests
    {
        [TestMethod]
        public void RepoBadHost()
        {
            IUserRepository repo = new UserRepository("https://badhost.com");
            var service = new UserService(repo);
            var response = service.UsersGet();
            Assert.AreEqual(false, response.Result.IsValid);
            Assert.IsTrue(response.Result.Error.ErrorMessage.Contains("No connection could be made because the target machine actively refused i"));
        }
    }
}
