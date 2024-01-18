using AutoMapper;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Movie.INFARSTRUTURE;
using Movie.INFARSTRUTURE.Entities;
using Movie.SERVICES.Interfaces;
using Movie.SERVICES.Interfaces.IServices;
using Movie.SERVICES.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.SERVICES.Services
{
    public class UserService : IUserService
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
        public async Task<LoginResultVm> GetUserToContext(Guid id)
        {
            return await _unitOfWork.Users.GetByIdUser(id);
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

        public async Task<bool> Register(RegisterViewModel register)
        {
            if (await _unitOfWork.Users.CheckEmailSignUp(register.email))
            {
                throw new Exception("Email or UserName already exist");
            }
            var user = _mapper.Map<User>(register);
            if (user != null)
            {
                user.user_id = Guid.NewGuid();
                user.password = BCrypt.Net.BCrypt.HashPassword(register.password);
                user.phone = register.phone;
                user.email = register.email;
                user.role_id = 1;
                user.gender = register.gender;
                user.address = register.address;
                user.regis_date = DateTime.UtcNow;
                await _unitOfWork.Users.Add(user);
                var result = _unitOfWork.Save();
                if (result > 0)
                {
                    return true;
                }
                else return false;
            }
            return false;
        }

    }
}
