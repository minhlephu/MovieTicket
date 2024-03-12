using AutoMapper;
using Movie.INFARSTRUTURE.Entities;
using Movie.INFARSTRUTURE.Models.TimeFrame;
using Movie.INFARSTRUTURE.Models.UserModel;

namespace MovieApi.Extensions.Mappers
{
    public class TimeFrameMapper : Profile
    {
        public TimeFrameMapper()
        {
            CreateMap<TimeFrame, TimeFrameResultVm>().ReverseMap();
            CreateMap<TimeFrame, TimeFrameViewModel>().ReverseMap();
        }
    }
}

