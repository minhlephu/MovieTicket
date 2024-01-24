using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.INFARSTRUTURE.Models.MovieModel;
using Movie.SERVICES.Interfaces.IRepositories;
using System.Security.AccessControl;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMapper _mapper;
        private IMovieRepository _movieRepository;
        public MovieController(IMovieRepository movieRepository, IMapper mapper)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }
        [Route("Movies")]
        [HttpGet]
        public async Task<IActionResult> GetMovieList()
        {
            var movieList = await _movieRepository.GetAll();
            if (movieList == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No movie in database");
            }
            return StatusCode(StatusCodes.Status200OK, movieList);
        }
        [Route("CreateMovie")]
        [HttpPost]
        public  async Task<IActionResult> CreateMovie(MovieViewModel movieVM)
        {
            var movie = _mapper.Map<Movie.INFARSTRUTURE.Entities.Movie>(movieVM);
            await _movieRepository.CreateAsync(movie);
            await _movieRepository.SaveChangesAsync();
            var result = _mapper.Map<MovieViewModel>(movie);
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
