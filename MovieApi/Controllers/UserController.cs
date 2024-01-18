using Microsoft.AspNetCore.Mvc;
using Movie.SERVICES.Interfaces;
using Movie.SERVICES.Models.UserModel;
using MovieApi.Interfaces;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private IUserService _userService;
        private IJwtUtils _jwtUtils;
        public UserController(IUserService userService, IJwtUtils jwtUtils)
        {
            _userService = userService;
            _jwtUtils = jwtUtils;
        }
        [Route("SignIn")]
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel request)
        {
            var response = await _userService.Login(request);
            var jwtToken = _jwtUtils.GenerateJwtToken(response);
            return Ok(new { token = jwtToken, response });
        }
        [Route("SignUp")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel request)
        {
            var response = await _userService.Register(request);
            return Ok(response);
        }
    }
}
 