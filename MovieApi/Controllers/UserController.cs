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
        public async Task<IActionResult> Login([FromBody] LoginViewModel request)
        {
            var res = await _userRepository.SignIn(request);
            var result = _mapper.Map<LoginResultVm>(res);
            var jwtToken = _jwtUtils.GenerateJwtToken(result);
            return Ok(new { token = jwtToken, result });
        }
        [Route("SignUp")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel request)
        {
            //if (await _userRepository.CheckEmailSignUp(request.email))
            //{
            //    throw new Exception("Email already exist");
            //}
            //if(await _userRepository.CheckUserNameSignUp(request.user_name))
            //{
            //    throw new Exception("Username already exist");
            //}
            //var user = _mapper.Map<Movie.INFARSTRUTURE.Entities.User>(request);
            //user.user_id = Guid.NewGuid();
            //user.password = BCrypt.Net.BCrypt.HashPassword(user.password);
            //user.role_id = 1;
            //user.regis_date = DateTime.Now;
            //await _userRepository.CreateAsync(user);
            //await _userRepository.SaveChangesAsync();
            return Ok();
        }
    }
}
