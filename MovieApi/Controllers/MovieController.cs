using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.INFARSTRUTURE.Models.CinemaModel;
using Movie.INFARSTRUTURE.Models.MovieModel;
using Movie.SERVICES.Interfaces.IRepositories;
using Movie.SERVICES.Repositories;
using MovieApi.Extensions;
using MovieApi.Helpers;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
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
        public async Task<IActionResult> GetMovieList([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? filter = "")
        {
            var movieList = await _movieRepository.GetListMovie(page, pageSize, filter);
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

            var result = new Response<MovieResultVm>
            {
                Data = _mapper.Map<MovieResultVm>(movie),
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
                return NotFound(new Response
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
            var result = _mapper.Map<MovieResultVm>(movie);
            return StatusCode(StatusCodes.Status200OK, result);
        }
        [Route("CreateMovieUpload")]
        [HttpPost]
        public async Task<IActionResult> CreateMovieUpload([FromForm] string datajson, IFormFile[] fileImages, IFormFile filePoster)
        {
            var movie = JsonConvert.DeserializeObject<Movie.INFARSTRUTURE.Entities.Movie>(datajson);
            string images = "";
            foreach (var file in fileImages)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);
                using (var stream = System.IO.File.Create(path))
                {
                    await file.CopyToAsync(stream);

                }
                images += "/images/" + file.FileName + ";";
            }
            var pathPoster = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", filePoster.FileName);
            using (var stream = System.IO.File.Create(pathPoster))
            {
                await filePoster.CopyToAsync(stream);

            }
            var poster = "/images/" + filePoster.FileName;
            movie.Image = images;
            movie.Poster = poster;
            await _movieRepository.CreateAsync(movie);
            await _movieRepository.SaveChangesAsync();
            var result = _mapper.Map<MovieResultVm>(movie);
            return StatusCode(StatusCodes.Status200OK, result);
        }
        [Authorize(Roles = AppRole.Admin)]
        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateMovie([Required] int id, MovieViewModel movieVm)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null)
            {
                return BadRequest(new Response
                {
                    Status = "Error",
                    Code = StatusCodes.Status204NoContent,
                    Message = "No movie found to update"
                });
            }
            var movieUpdate = _mapper.Map(movieVm, movie);
            await _movieRepository.UpdateAsync(movieUpdate);
            var result = new Response
            {
                Code = StatusCodes.Status200OK,
                Status = "Success",
                Message = "Update movie success"
            };
            return Ok(result);
        }
    }
}
