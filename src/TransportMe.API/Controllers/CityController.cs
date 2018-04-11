using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public IActionResult GetCities()
        {
            var entityList = this.cityDataRepository.GetCities();
            var response = Mapper.Map<IEnumerable<CityDto>>(entityList);
            return Ok(response);
        }

        [HttpGet("{cityId}")]
        public IActionResult GetCity(int cityId)
        {
            var entity = this.cityDataRepository.GetCity(cityId);
            var response = Mapper.Map<CityDto>(entity);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult AddCity([FromBody] CityDto city)
        {
            var cityToAdd = Mapper.Map<City>(city);
            this.cityDataRepository.AddCity(cityToAdd);
            var response = this.cityDataRepository.Save();
            if (response)
            {
                return CreatedAtRoute("GetCity", new
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