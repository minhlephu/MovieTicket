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
            var result = await _userRepository.SignInAsync(request);
            if (string.IsNullOrEmpty(result))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Username or password incorect" });
            }
            return Ok(result);          
        }
        [Route("SignUp")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel request)
        {
            var userExists = await _userManager.FindByNameAsync(request.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });
            var user  = new ApplicationUser
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.Username,              
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            if (!await _roleManager.RoleExistsAsync(AppRole.Admin))
            {
                await _roleManager.CreateAsync(new IdentityRole(AppRole.Admin));

            }
            if (!await _roleManager.RoleExistsAsync(AppRole.Customer))
            {
                await _roleManager.CreateAsync(new IdentityRole(AppRole.Customer));

            }
            await _userManager.AddToRoleAsync(user, AppRole.Customer);
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
           
        }
    }
}
