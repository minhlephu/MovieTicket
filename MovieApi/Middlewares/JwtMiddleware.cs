using Movie.SERVICES.Interfaces.IServices;
using MovieApi.Interfaces;

namespace MovieApi.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        public JwtMiddleware(RequestDelegate next) { _next = next; }
        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateJwtToken(token);
            if (userId != null)
            {
                //attach user to context on successful jwt validation
                context.Items["User"] = userService.GetUserToContext(userId.Value).Result;
            }

            await _next(context);
        }
    }
}
