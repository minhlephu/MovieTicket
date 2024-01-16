using Movie.INFARSTRUTURE;
using Movie.INFARSTRUTURE.Entities;
using Movie.SERVICES.Interfaces;
using Movie.SERVICES.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.SERVICES.Repositories
{
    public class UserRepository :GenericRipository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context):base(context) {
        
        
        }

        public Task<bool> CheckEmailSignUp(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckUserNameSignUp(string username)
        {
            throw new NotImplementedException();
        }

        public Task<User> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<LoginResultVm> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<LoginResultVm> GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

    }
}
