using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TransportMe.API.Data;

namespace TransportMe.API.Controllers
{
    [Route("api/transport")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        [HttpGet("modes")]
        public IActionResult GetModes()
        {
            var result = TransportDataStore.Current.TransportModes;
            return this.Ok(result);
        }

        [HttpGet("{cityId}/services")]
        public IActionResult GetServices(int cityId)
        {
            var selectedCity = CityDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (selectedCity == null)
            {
                ModelState.AddModelError("CityId", "Not a valid city");
                return BadRequest(ModelState);
            }

            var result = TransportDataStore.Current.TransportServices
                                                   .Where(s => s.CityId == cityId)
                                                   .ToList();
            return Ok(result);
        }
    }
}
