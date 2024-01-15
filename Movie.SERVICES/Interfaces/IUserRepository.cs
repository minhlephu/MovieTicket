using Movie.INFARSTRUTURE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.SERVICES.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByUsername(string username);

        Task<bool> CheckUserNameSignUp(string username);

        Task<bool> CheckEmailSignUp(string email);
    }
}
