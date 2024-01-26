using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.INFARSTRUTURE.Models.ShowModel;
using Movie.INFARSTRUTURE.Models.TimeFrame;
using Movie.SERVICES.Interfaces.IRepositories;
using MovieApi.Extensions;
using System.ComponentModel.DataAnnotations;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private IMapper _mapper;
        private IShowRepository _showRepository;
        public ShowController(IShowRepository showRepository, IMapper mapper)
        {
            _mapper = mapper;
            _showRepository = showRepository;
        }
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetInfoShow(int id)
        {
            var show = await _showRepository.GetByIdAsync(id);
            if (show == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No showtime in database");
            }

            var result = new Response<ShowResultVm>
            {
                Data = _mapper.Map<ShowResultVm>(show),
                Code = StatusCodes.Status200OK,
                Status = "Success",
                Message = "Get showtime success"
            };
            return Ok(result);
        }
        [Route("DeleteShow")]
        [HttpDelete]
        public async Task<IActionResult> DeleteShow(int id)
        {
            var show = await _showRepository.GetByIdAsync(id);
            if (show == null)
            {
                return NotFound(new Response
                {
                    Status = "Error",
                    Code = StatusCodes.Status204NoContent,
                    Message = "No show found to delete"
                });
            }
            await _showRepository.DeleteAsync(show);
            await _showRepository.SaveChangesAsync();
            return Ok(new Response { Status = "Success", Message = "Delete show success", Code = StatusCodes.Status200OK });

        }
        [Route("CreateTimeFrame")]
        [HttpPost]
        public async Task<IActionResult> CreateCinema(ShowViewModel showVm)
        {
            var show = _mapper.Map<Movie.INFARSTRUTURE.Entities.Show>(showVm);
            await _showRepository.CreateAsync(show);
            await _showRepository.SaveChangesAsync();
            var resultData = _mapper.Map<ShowResultVm>(show);
            var result = new Response<ShowResultVm>
            {
                Data = resultData,
                Code = StatusCodes.Status200OK,
                Status = "Success",
                Message = "Create show success"
            };
            return Ok(result);
        }
        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateShow([Required] int id, ShowViewModel showVm)
        {
            var show = await _showRepository.GetByIdAsync(id);
            if (show == null)
            {
                return NotFound(new Response
                {
                    Status = "Error",
                    Code = StatusCodes.Status204NoContent,
                    Message = "No movie found to delete"
                });
            }
            var showUpdate = _mapper.Map(showVm, show);
            await _showRepository.UpdateAsync(showUpdate);
            var result = new Response
            {
                Code = StatusCodes.Status200OK,
                Status = "Success",
                Message = "Update show success"
            };
            return Ok(result);
        }
    }
}
