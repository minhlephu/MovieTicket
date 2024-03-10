using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.INFARSTRUTURE.Models.CinemaModel;
using Movie.INFARSTRUTURE.Models.TimeFrame;
using Movie.SERVICES.Interfaces.IRepositories;
using Movie.SERVICES.Repositories;
using MovieApi.Extensions;
using MovieApi.Helpers;
using System.ComponentModel.DataAnnotations;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeFrameController : ControllerBase
    {
        private IMapper _mapper;
        private ITimeFrameRepository _timeFrameRepository;
        public TimeFrameController(ITimeFrameRepository timeFrameRepository, IMapper mapper)
        {
            _mapper = mapper;
            _timeFrameRepository = timeFrameRepository;
        }
        [Route("TimeFrames")]
        [HttpGet]
        public async Task<IActionResult> GetListTimeFrame([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var timeFrameList = await _timeFrameRepository.GetListTimeFrame(page, pageSize);
            if (timeFrameList == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No timeframe in database");
            }
            return StatusCode(StatusCodes.Status200OK, timeFrameList);
        }
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetInfoTimeFrame(int id)
        {
            var timeFrame = await _timeFrameRepository.GetByIdAsync(id);
            if (timeFrame == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No timeframe in database");
            }

            var result = new Response<TimeFrameResultVm>
            {
                Data = _mapper.Map<TimeFrameResultVm>(timeFrame),
                Code = StatusCodes.Status200OK,
                Status = Status.Success,
                Message = "Get timeframe success"
            };
            return Ok(result);
        }
        [Route("DeleteTimeFrame")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTimeFrame([FromQuery] int id)
        {
            var timeFrame = await _timeFrameRepository.GetByIdAsync(id);
            if (timeFrame == null)
            {
                return NotFound(new Response
                {
                    Status = Status.Error,
                    Code = StatusCodes.Status204NoContent,
                    Message = "No fimeframe found to delete"
                });
            }
            await _timeFrameRepository.DeleteAsync(timeFrame);
            await _timeFrameRepository.SaveChangesAsync();
            return Ok(new Response { Status = Status.Success, Message = "Delete timeframe success", Code = StatusCodes.Status200OK });

        }
        [Route("CreateTimeFrame")]
        [HttpPost]
        public async Task<IActionResult> CreateTimeFrame(TimeFrameViewModel timeFrameVm)
        {
            var timeFrame = _mapper.Map<Movie.INFARSTRUTURE.Entities.TimeFrame>(timeFrameVm);
            await _timeFrameRepository.CreateAsync(timeFrame);
            await _timeFrameRepository.SaveChangesAsync();
            var resultData = _mapper.Map<TimeFrameResultVm>(timeFrame);
            var result = new Response<TimeFrameResultVm>
            {
                Data = resultData,
                Code = StatusCodes.Status200OK,
                Status = Status.Success,
                Message = "Create timeframe success"
            };
            return Ok(result);
        }
        [Route("UpdateTimeFrame")]
        [HttpPut]
        public async Task<IActionResult> UpdateTimeFrame([Required] int id, TimeFrameViewModel timeFrameVm)
        {
            var timeFrame = await _timeFrameRepository.GetByIdAsync(id);
            if (timeFrame == null)
            {
                return NotFound(new Response
                {
                    Status = Status.Error,
                    Code = StatusCodes.Status204NoContent,
                    Message = "No movie found to delete"
                });
            }
            var cinemaData = _mapper.Map(timeFrameVm, timeFrame);
            await _timeFrameRepository.UpdateAsync(cinemaData);
            var result = new Response
            {
                Code = StatusCodes.Status200OK,
                Status = Status.Success,
                Message = "Update timeframe success"
            };
            return Ok(result);
        }
    }
}
