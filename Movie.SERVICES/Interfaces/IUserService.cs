using Movie.INFARSTRUTURE.Entities;
using Movie.SERVICES.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.SERVICES.Interfaces
{
    public interface IUserService
    {
        Task<LoginResultVm> Login(LoginViewModel request);
        Task<LoginResultVm> GetUserToContext(int id);
    }
}
