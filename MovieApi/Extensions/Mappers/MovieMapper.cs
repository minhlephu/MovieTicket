using AutoMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Movie.INFARSTRUTURE.Entities;
using Movie.INFARSTRUTURE.Models.MovieModel;
namespace MovieApi.Extensions.Mappers
{
    public class MovieMapper:Profile  
    {
        public MovieMapper()
        {
            CreateMap<Movie.INFARSTRUTURE.Entities.Movie, MovieViewModel>().ReverseMap();
        }
    }
}
