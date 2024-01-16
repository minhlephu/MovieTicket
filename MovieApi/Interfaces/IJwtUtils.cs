using Movie.SERVICES.Models.UserModel;

namespace MovieApi.Interfaces
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(LoginResultVm user);
        public Guid? ValidateJwtToken(string token);
    }
}
