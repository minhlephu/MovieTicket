using Movie.SERVICES.Models.UserModel;

namespace MovieApi.Interfaces
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(LoginResultVm user);
        public int? ValidateJwtToken(string token);
    }
}
