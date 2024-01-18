using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.INFARSTRUTURE.Entities;
using Movie.SERVICES.Models.UserModel;

namespace Movie.SERVICES.Interfaces.IServices
{
    public interface IUserService
    {
        Task<LoginResultVm> Login(LoginViewModel request);
        Task<User> Delete(Guid id);
        Task<LoginResultVm> GetUserToContext(Guid id);
        Task<bool> CheckEmailSignUp(string email);
        Task<bool> Register(RegisterViewModel register);
    }
}
