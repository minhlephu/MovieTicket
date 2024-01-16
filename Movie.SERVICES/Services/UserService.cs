using AutoMapper;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Movie.INFARSTRUTURE;
using Movie.SERVICES.Interfaces;
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
            return await _unitOfWork.Users.GetById(id);
        }

        public Task<LoginResultVm> Login(LoginViewModel request)
        {
            var user = _context.Users.SingleOrDefault(x=>x.email == request.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.password))
            {
                throw new Exception("Username or password is incorrect");
            }
          
        }
    }
}
