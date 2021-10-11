using Microsoft.Extensions.Configuration;
using SevenPlus.Services;
using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace SevenPlus.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            MainAsync().Wait();
        }
        static async Task MainAsync()
        {
            var url = "https://f43qgubfhf.execute-api.ap-southeast-2.amazonaws.com/sampletest";
            var repo = new UserRepository(url);
            var service = new UserService(repo);

            var response = await service.UserGet(42);

            if (!response.IsValid)
            {
                Console.WriteLine("Error reading user");
                return;
            }

            var user = response.ReturnValue;
            if (user == null)
            {
                Console.WriteLine($"User not found");
            }
            else
            {
                Console.WriteLine($"User:{user.first} {user.last}");
            }

            var responseAllUsers =await  service.UsersGet();
            if (!responseAllUsers.IsValid)
            {
                Console.WriteLine("Error reading user");
                return;
            }

            var users = responseAllUsers.ReturnValue.ToArray();

            var agesUsers = users.Where(u => u.age == 23);
            var firstNames = string.Join(", ", agesUsers.Select(u => u.first));
            Console.Write("Users who are 23:");
            Console.WriteLine(firstNames);


            // So normally I wouldn't do this LinQ ninja, because it might work...  Its horrible to maintain!
            // But, here you go!
            var usersGroupBy = responseAllUsers.ReturnValue.GroupBy(g => g.age, g => g.gender).ToArray();
            var usersGroupBySorted = usersGroupBy.OrderBy(o => o.Key);
            foreach(var u in usersGroupBySorted)
            {
                var groupBySex = u.Distinct().ToArray();
                Console.Write($"Age: {u.Key} ");
                foreach(var g in groupBySex)
                {
                    Console.Write($"{g}:{u.Count(c => c == g)} ");
                }

                Console.WriteLine();

            }


            Console.ReadLine();
        }

    }
}
