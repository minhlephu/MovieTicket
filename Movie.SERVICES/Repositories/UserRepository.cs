using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMapper _mapper;
        public UserRepository(ApplicationDbContext context , IMapper mapper) :base(context) {

            _mapper = mapper;
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

        public async Task<LoginResultVm> GetByIdUser(Guid id)
        {
            var res = await _context.Users.FirstOrDefaultAsync(x=>x.user_id==id);
            return _mapper.Map<LoginResultVm>(res);
        }

        public Task<LoginResultVm> GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

    }
}
