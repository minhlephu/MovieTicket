using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movie.INFARSTRUTURE.Entities;
using Movie.INFARSTRUTURE.Models.UserModel;
using Movie.SERVICES.Interfaces.IRepositories;
using MovieApi.Extensions;
using MovieApi.Helpers;


namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private IUserRepository _userRepository;
        private IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper, UserManager<ApplicationUser> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
            _roleManager = roleManager;
        }
        [Route("SignIn")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel request)
        {
            var resultData = await _userRepository.SignInAsync(request);
            if (string.IsNullOrEmpty(resultData))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = 101, Message = "Username or password incorect" });
            }

            var result = new Response<string>()
            {
                Data = resultData,
                Status = 100,
                Code = StatusCodes.Status200OK,
                Message = "Login success"

            };
            return Ok(result);          
        }
        [Route("SignUp")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel request)
        {
            var userNameExists = await _userManager.FindByNameAsync(request.Username);
            if (userNameExists != null)
                return Ok(new Response { Status = 102, Message = "UserName already exists!" });
            var userEmailExists = await _userManager.FindByEmailAsync(request.Email);
            if (userEmailExists != null)
                return Ok(new Response { Status = 103, Message = "Email already exists!" });
            var user  = new ApplicationUser
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.Username,              
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status =Status.Error, Message = "User creation failed! Please check user details and try again." });
            if (!await _roleManager.RoleExistsAsync(AppRole.Admin))
            {
                await _roleManager.CreateAsync(new IdentityRole(AppRole.Admin));

            }
            if (!await _roleManager.RoleExistsAsync(AppRole.Customer))
            {
                await _roleManager.CreateAsync(new IdentityRole(AppRole.Customer));

            }
            await _userManager.AddToRoleAsync(user, AppRole.Customer);
            return Ok(new Response { Status = Status.Success, Message = "User created successfully!" });
           
        }
    }
}
