using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TransportMe.API.Models;
using TransportMe.API.Services;

namespace TransportMe.API.Controllers
{
    [Route("api/v1/transport")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        private readonly ITransportDataRepository transportDataRepository;
        private readonly ICityDataRepository cityDataRepository;

        public TransportController(
            ICityDataRepository cityDataRepository,
            ITransportDataRepository transportDataRepository)
        {
            this.cityDataRepository = cityDataRepository;
            this.transportDataRepository = transportDataRepository;
        }

        [HttpGet("modes")]
        public IActionResult GetModes()
        {
            var entityList = this.transportDataRepository.GetTransportModes();
            var response = Mapper.Map<IEnumerable<TransportModeDto>>(entityList);
            return this.Ok(response);
        }

        [HttpGet("{cityId}/services")]
        public IActionResult GetServices(int cityId)
        {
            var selectedCity = this.cityDataRepository.GetCity(cityId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (selectedCity == null)
            {
                ModelState.AddModelError("CityId", "Not a valid city");
                return BadRequest(ModelState);
            }

            var entityList = this.transportDataRepository.GetTransportService(cityId);
            var response = Mapper.Map<IEnumerable<TransportServiceDto>>(entityList);
            return Ok(response);
        }
    }
}
