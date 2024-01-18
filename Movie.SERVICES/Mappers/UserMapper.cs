using AutoMapper;
using Movie.INFARSTRUTURE.Entities;
using Movie.SERVICES.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.SERVICES.Mappers
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
