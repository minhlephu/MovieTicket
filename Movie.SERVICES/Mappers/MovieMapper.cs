using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Movie.INFARSTRUTURE.Entities;
using Movie.SERVICES.Models.MovieModel;
using Movie.SERVICES.Models.UserModel;

namespace Movie.SERVICES.Mappers
{
    public class MovieMapper:Profile
    {
        public MovieMapper()
        {
            CreateMap<INFARSTRUTURE.Entities.Movie, MovieViewModel>().ReverseMap();
        }
    }
}
