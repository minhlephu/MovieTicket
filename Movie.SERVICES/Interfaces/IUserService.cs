using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.SERVICES.Models.UserModel;

namespace Movie.SERVICES.Interfaces
{
    public interface IUserService
    {
        Task<LoginResultVm> Login(LoginViewModel request);
    }
}
