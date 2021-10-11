using SevenPlus.Services.Models;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace SevenPlus.Services
{
    public class UserService
    {
        IUserRepository _repo;
        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<APIResponse<User>> UserGet(int ID)
        {
            var ret = new APIResponse<User>();
            try
            {
                var users = await _repo.UsersRead();

                ret.ReturnValue = users.FirstOrDefault(u => u.id == ID);
            }
            catch (Exception e)
            {
                ret.IsValid = false;
                var msg = e.Message;
                if (e.InnerException != null)
                {
                    msg += "\r\n" + e.InnerException.Message;
                }
                ret.Error = new APIResponseError(e);
            }

            return ret;
        }

        public async Task<APIResponse<User[]>> UsersGet()
        {
            var ret = new APIResponse<User[]>();
            try
            {
                var users = await _repo.UsersRead();
                ret.ReturnValue = users.ToArray();
            }
            catch (Exception e)
            {
                ret.IsValid = false;
                var msg = e.Message;
                if (e.InnerException != null)
                {
                    msg += "\r\n" + e.InnerException.Message;
                }
                ret.Error = new APIResponseError(e);
            }

            return ret;
        }
    }
}
