using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.SERVICES.Interfaces.IRepositories;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private IMapper _mapper;
        private ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository, IMapper mapper)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
        }

        [Route("List-city")]
        [HttpGet]
        public async Task<IActionResult> GetListCity ()
        {
            var cityList = await _cityRepository.GetAll();
            if(cityList == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No movie in database");
            }

            return StatusCode(StatusCodes.Status200OK, cityList);
        }

        [Route("Name-city/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetCityById (int id)
        {
            var city = await _cityRepository.GetByIdAsync(id);
            if(city == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No city in database");
            }
            return Ok(city.CityName);
        }

    }
}
