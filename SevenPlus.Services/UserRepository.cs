using Newtonsoft.Json;
using SevenPlus.Services.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SevenPlus.Services
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> UsersRead();
    }
    public class UserRepository : IUserRepository
    {
        // https://www.aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/
        // the holy war!  Should httpclient be static?
        private static HttpClient httpClient = new HttpClient();

        string _config;
        public UserRepository(string config)
        {
            _config = config;
        }
        public async Task<IEnumerable<User>> UsersRead()
        {
            using (var response = await httpClient.GetAsync(_config))
            {
                using (var content = response.Content)
                {
                    var json = await content.ReadAsStringAsync();
                    var users = JsonConvert.DeserializeObject<List<User>>(json);
                    return users;
                }
            }
        }
    }
}
