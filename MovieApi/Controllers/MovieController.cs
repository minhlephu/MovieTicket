using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.INFARSTRUTURE.Models.MovieModel;
using Movie.SERVICES.Interfaces.IRepositories;
using MovieApi.Extensions;
using System.Net.WebSockets;
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
        public IActionResult GetMovieList([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? filter = "")
        {
            var movieList = _movieRepository.GetListMovie(page, pageSize, filter);
            if (movieList == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No movie in database");
            }
            return StatusCode(StatusCodes.Status200OK, movieList);
        }
        [Route("MovieInfo/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetInfoMovie(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No movie in database");
            }

            var result = new Response<MovieViewModel>
            {
                Data = _mapper.Map<MovieViewModel>(movie),
                Code = StatusCodes.Status200OK,
                Status = "0",
                Message = "Ok"
            };
            return Ok(result);
        }
        [Route("DeleteMovie")]
        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null)
            {
                return BadRequest(new Response
                {
                    Status = "Error",
                    Code = StatusCodes.Status204NoContent,
                    Message = "No movie found to delete"
                });
            }
            await _movieRepository.DeleteAsync(movie);
            await _movieRepository.SaveChangesAsync();
            return Ok(new Response { Status = "Success", Message = "Delete success", Code = StatusCodes.Status200OK });

        }
        [Route("CreateMovie")]
        [HttpPost]
        public async Task<IActionResult> CreateMovie(MovieViewModel movieVM)
        {
            var movie = _mapper.Map<Movie.INFARSTRUTURE.Entities.Movie>(movieVM);
            await _movieRepository.CreateAsync(movie);
            await _movieRepository.SaveChangesAsync();
            var result = _mapper.Map<MovieViewModel>(movie);
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
