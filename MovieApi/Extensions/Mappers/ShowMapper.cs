using AutoMapper;
using Movie.INFARSTRUTURE.Entities;
using Movie.INFARSTRUTURE.Models.ShowModel;
using Movie.INFARSTRUTURE.Models.UserModel;

namespace MovieApi.Extensions.Mappers
{
    public class ShowMapper : Profile
    {
        public ShowMapper()
        {
            CreateMap<Show, ShowViewModel>().ReverseMap();
            CreateMap<Show, ShowResultVm>().ReverseMap();
        }
    }
}
