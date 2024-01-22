using Microsoft.AspNetCore.Identity;
using Movie.INFARSTRUTURE.Entities;
using Movie.INFARSTRUTURE.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Movie.SERVICES.Interfaces.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> SignIn(LoginViewModel login);
        Task<User> GetByIdUser(Guid id);
        Task<User> GetUserToContext(Guid id);
        Task Delete(User user);
        Task<bool> CheckUserNameSignUp(string username);
        Task<bool> CheckEmailSignUp(string email);
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task<IEnumerable<User>> GetUsers();
        Task<string> SignInAsync(LoginViewModel login);
        Task<IdentityResult> SignUpAsync(ApplicationUser register);

    }
}
