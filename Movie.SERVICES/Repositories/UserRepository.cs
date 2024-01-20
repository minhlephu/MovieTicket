using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movie.INFARSTRUTURE;
using Movie.INFARSTRUTURE.Entities;
using Movie.INFARSTRUTURE.Models.UserModel;
using Movie.SERVICES.Interfaces;
using Movie.SERVICES.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.SERVICES.Repositories
{
    public class UserRepository :GenericRipository<User>, IUserRepository
    {

        public UserRepository(ApplicationDbContext context,IUnitOfWork unitOfWork) :base(context,unitOfWork) {

        }

        public async Task<bool> CheckEmailSignUp(string email)
        {
            return await _context.Users.AnyAsync(u => u.email==email);
        }

        public async Task<bool> CheckUserNameSignUp(string username)
        {
            return await _context.Users.AnyAsync(u => u.user_name == username);
        }

        public  Task CreateUser(User user)
        {
            return CreateAsync(user);
        }

        public Task Delete(User user)
        {
            return DeleteAsync(user);
        }

        public Task<User> GetByIdUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(User user)
        {
            return UpdateAsync(user);
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            return GetAll();
        }

        public Task<User> SignIn(LoginViewModel login)
        {
            throw new NotImplementedException();
        }
        public Task<User> GetUserToContext(Guid id)
        {
            return GetByIdUser(id);
        }

    }
}
