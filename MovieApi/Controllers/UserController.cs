using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movie.INFARSTRUTURE.Models.UserModel;
using Movie.SERVICES.Interfaces.IRepositories;
using MovieApi.Interfaces;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        private IJwtUtils _jwtUtils;
        private IMapper _mapper;
        public UserController(IJwtUtils jwtUtils, IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }
        [Route("SignIn")]
        [HttpPost]

        [Route("SignUp")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel request)
        {
            if (await _userRepository.CheckEmailSignUp(request.email) || await _userRepository.CheckUserNameSignUp(request.user_name))
            {
                throw new Exception("Email or UserName already exist");

            }
            var user = _mapper.Map<Movie.INFARSTRUTURE.Entities.User>(request);
            user.user_id = Guid.NewGuid();
            user.password = BCrypt.Net.BCrypt.HashPassword(user.password);
            user.role_id = 1;
            user.regis_date = DateTime.Now;
            await _userRepository.CreateAsync(user);
            var result = _userRepository.SaveChangesAsync();
            return Ok(result);
        }
    }
}
