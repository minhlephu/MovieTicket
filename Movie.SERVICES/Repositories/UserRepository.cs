using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Movie.INFARSTRUTURE;
using Movie.INFARSTRUTURE.Entities;
using Movie.INFARSTRUTURE.Models.UserModel;
using Movie.SERVICES.Interfaces;
using Movie.SERVICES.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Movie.SERVICES.Repositories
{
    public class UserRepository : GenericRipository<INFARSTRUTURE.Entities.User>, IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UserRepository(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,IConfiguration configuration, ApplicationDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._configuration = configuration;
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

        public async Task<User> SignIn(LoginViewModel login)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.user_name == login.UserName);
            if (user == null || !BCrypt.Net.BCrypt.Verify(login.Password, user.password)){
                throw new Exception("Username or password is incorrect");
            }
            return user;
        }
        public Task<User> GetUserToContext(Guid id)
        {
            return GetByIdUser(id);
        }

        public async Task<string> SignInAsync(LoginViewModel login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, login.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
               return new JwtSecurityTokenHandler().WriteToken(token);                               
            }
            return null;
        }
        public async Task<IdentityResult> SignUpAsync(ApplicationUser user)
        {
            var result = await _userManager.CreateAsync(user, user.PasswordHash);
            return result;
        }
      
    }
}
