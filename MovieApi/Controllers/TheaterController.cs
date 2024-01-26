using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.INFARSTRUTURE.Models.TheaterModel;
using Movie.INFARSTRUTURE.Models.TimeFrame;
using Movie.SERVICES.Interfaces.IRepositories;
using MovieApi.Extensions;
using System.ComponentModel.DataAnnotations;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheaterController : ControllerBase
    {
        private IMapper _mapper;
        private ITheaterRepository _theaterRepository;
        public TheaterController(ITheaterRepository theaterRepository, IMapper mapper)
        {
            _mapper = mapper;
            _theaterRepository = theaterRepository;
        }
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetInfoTheater(int id)
        {
            var theater = await _theaterRepository.GetByIdAsync(id);
            if (theater == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No theater in database");
            }

            var result = new Response<TheaterResultVm>
            {
                Data = _mapper.Map<TheaterResultVm>(theater),
                Code = StatusCodes.Status200OK,
                Status = "Success",
                Message = "Get theater success"
            };
            return Ok(result);
        }
        [Route("DeleteTheater")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTheater(int id)
        {
            var theater = await _theaterRepository.GetByIdAsync(id);
            if (theater == null)
            {
                return NotFound(new Response
                {
                    Status = "Error",
                    Code = StatusCodes.Status204NoContent,
                    Message = "No theater found to delete"
                });
            }
            await _theaterRepository.DeleteAsync(theater);
            await _theaterRepository.SaveChangesAsync();
            return Ok(new Response { Status = "Success", Message = "Delete theater success", Code = StatusCodes.Status200OK });

        }
        [Route("CreateTheater")]
        [HttpPost]
        public async Task<IActionResult> CreateTheater(TheaterViewModel theaterVm)
        {
            var theater = _mapper.Map<Movie.INFARSTRUTURE.Entities.Theater>(theaterVm);
            await _theaterRepository.CreateAsync(theater);
            await _theaterRepository.SaveChangesAsync();
            var resultData = _mapper.Map<TheaterResultVm>(theater);
            var result = new Response<TheaterResultVm>
            {
                Data = resultData,
                Code = StatusCodes.Status200OK,
                Status = "Success",
                Message = "Create theater success"
            };
            return Ok(result);
        }
        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateTheater([Required] int id, TheaterViewModel theaterVm)
        {
            var theater = await _theaterRepository.GetByIdAsync(id);
            if (theater == null)
            {
                return NotFound(new Response
                {
                    Status = "Error",
                    Code = StatusCodes.Status204NoContent,
                    Message = "No theater found to delete"
                });
            }
            var theaterUpdate = _mapper.Map(theaterVm, theater);
            await _theaterRepository.UpdateAsync(theaterUpdate);
            var result = new Response
            {
                Code = StatusCodes.Status200OK,
                Status = "Success",
                Message = "Update theater success"
            };
            return Ok(result);
        }
    }
}
