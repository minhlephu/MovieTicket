using AutoMapper;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Movie.INFARSTRUTURE;
using Movie.INFARSTRUTURE.Entities;
using Movie.INFARSTRUTURE.Models.UserModel;
using Movie.SERVICES.Interfaces;
using Movie.SERVICES.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.SERVICES.Services
{
    public class UserService 
    {
        public IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public UserService(IMapper mapper, IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }
       

        public async Task<LoginResultVm> Login(LoginViewModel request)
        {
            var user =  _context.Users.SingleOrDefault(x => x.email == request.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.password))
            {
                throw new Exception("Username or password is incorrect");
            }
            return   _mapper.Map<LoginResultVm>(user);
        }

        public Task<User> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckEmailSignUp(string email)
        {
            throw new NotImplementedException();
        }

       

    }
}
