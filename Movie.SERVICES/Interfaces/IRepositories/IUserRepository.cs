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
    public interface IUserRepository : IGenericRepository<ApplicationUser>
    {
        Task<string> SignInAsync(LoginViewModel login);
        Task<IdentityResult> SignUpAsync(ApplicationUser register);

    }
}
