using SevenPlus.Services;
using SevenPlus.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevenPlus.UnitTests.Mocks
{
    public class MockRepository : IUserRepository
    {
        List<User> users = new List<User>();
        public MockRepository()
        {
            users.Add(new User {id=1, age = 20, gender = "Male" });
            users.Add(new User {id=2, age = 20, gender = "Male" });
            users.Add(new User {id=3, age = 21, gender = "Male" });
            users.Add(new User {id=4, age = 21, gender = "Female" });
            users.Add(new User {id=5, age = 21, gender = "Female" });
        }
        public Task<IEnumerable<User>> UsersRead()
        {
            return Task.Run(() =>
            {
                return users.AsEnumerable();
            });

        }
    }

}
