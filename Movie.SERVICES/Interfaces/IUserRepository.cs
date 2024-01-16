using Movie.INFARSTRUTURE.Entities;
using Movie.SERVICES.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.SERVICES.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<LoginResultVm> GetById(Guid id);
        Task<User> Delete(Guid id);
        Task<LoginResultVm> GetByUsername(string username);

        Task<bool> CheckUserNameSignUp(string username);

        Task<bool> CheckEmailSignUp(string email);
    }
}
