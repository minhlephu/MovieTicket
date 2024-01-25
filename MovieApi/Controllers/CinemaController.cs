using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using Movie.INFARSTRUTURE.Entities;
using Movie.INFARSTRUTURE.Models.CinemaModel;
using Movie.INFARSTRUTURE.Models.MovieModel;
using Movie.SERVICES.Interfaces.IRepositories;
using Movie.SERVICES.Repositories;
using MovieApi.Extensions;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private IMapper _mapper;
        private ICinemaRepository _cinemaRepository;
        public CinemaController(ICinemaRepository cinamaRepository, IMapper mapper)
        {
            _mapper = mapper;
            _cinemaRepository = cinamaRepository;
        }
        [Route("Cinema/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetInfoCinema(int id)
        {
            var cinema = await _cinemaRepository.GetByIdAsync(id);
            if (cinema == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No cinema in database");
            }

            var result = new Response<CinemaResultVm>
            {
                Data = _mapper.Map<CinemaResultVm>(cinema),
                Code = StatusCodes.Status200OK,
                Status = "Success",
                Message = "Get cinema success"
            };
            return Ok(result);
        }
        [Route("DeleteCinema")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCinema(int id)
        {
            var cinema = await _cinemaRepository.GetByIdAsync(id);
            if (cinema == null)
            {
                return BadRequest(new Response
                {
                    Status = "Error",
                    Code = StatusCodes.Status204NoContent,
                    Message = "No movie found to delete"
                });
            }
            await _cinemaRepository.DeleteAsync(cinema);
            await _cinemaRepository.SaveChangesAsync();
            return Ok(new Response { Status = "Success", Message = "Delete cinema success", Code = StatusCodes.Status200OK });

        }
        [Route("CreateCinema")]
        [HttpPost]
        public async Task<IActionResult> CreateCinema(CinemaViewModel cinemaVM)
        {
            var cinema = _mapper.Map<Movie.INFARSTRUTURE.Entities.Cinema>(cinemaVM);
            await _cinemaRepository.CreateAsync(cinema);
            await _cinemaRepository.SaveChangesAsync();
            var resultData = _mapper.Map<CinemaResultVm>(cinema);       
            var result = new Response<CinemaResultVm>
            {
                Data = resultData,
                Code = StatusCodes.Status200OK,
                Status = "Success",
                Message = "Get cinema success"
            };
            return Ok(result);
        }
        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateCinema([Required] int id,CinemaViewModel cinemaVM)
        {
            var cinema = await _cinemaRepository.GetByIdAsync(id);
            if (cinema == null)
            {
                return BadRequest(new Response
                {
                    Status = "Error",
                    Code = StatusCodes.Status204NoContent,
                    Message = "No movie found to delete"
                });
            }
            var cinemaData = _mapper.Map(cinemaVM, cinema);
            await _cinemaRepository.UpdateAsync(cinemaData);
            var result = new Response
            {
                Code = StatusCodes.Status200OK,
                Status = "Success",
                Message = "Update cinema success"
            };
            return Ok(result);
        }
    }
}
