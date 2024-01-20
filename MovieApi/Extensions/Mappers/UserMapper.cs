using AutoMapper;
using Movie.INFARSTRUTURE.Entities;
using Movie.INFARSTRUTURE.Models.UserModel;


namespace MovieApi.Extensions.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, LoginViewModel>().ReverseMap();
            CreateMap<User, LoginResultVm>().ReverseMap();
            CreateMap<User, RegisterViewModel>().ReverseMap();
        }
    }
}
