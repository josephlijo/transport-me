using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransportMe.API.Models;
using TransportMe.API.Services;
using TransportMe.Entities;

namespace TransportMe.API.Controllers
{
    [Route("api/v1/city")]
    public class CityController : Controller
    {
        private readonly ICityDataRepository cityDataRepository;

        public CityController(ICityDataRepository cityDataRepository)
        {
            this.cityDataRepository = cityDataRepository;
        }

        [HttpGet("names")]
        public async Task<IActionResult> GetCitiesAsync()
        {
            var entityList = await this.cityDataRepository.GetCitiesAsync();
            var response = Mapper.Map<IEnumerable<CityDto>>(entityList);
            return Ok(response);
        }

        [HttpGet("{cityId}")]
        public async Task<IActionResult> GetCityAsync(int cityId)
        {
            var entity = await this.cityDataRepository.GetCityAsync(cityId);
            var response = Mapper.Map<CityDto>(entity);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddCity([FromBody] CityDto city)
        {
            var cityToAdd = Mapper.Map<City>(city);
            this.cityDataRepository.AddCityAsync(cityToAdd);
            var response = await this.cityDataRepository.SaveAsync();
            if (response)
            {
                return CreatedAtRoute("GetCityAsync", new
                {
                    cityId = cityToAdd.Id
                }, Mapper.Map<CityDto>(cityToAdd));
            }
            else
            {
                return StatusCode(500, "Failed to save due to server error");
            }
        }
    }
}