using Microsoft.AspNetCore.Mvc;
using TransportMe.API.Data;

namespace TransportMe.API.Controllers
{
    [Route("api/v1/city")]
    public class CityController : Controller
    {
        [HttpGet("names")]
        public IActionResult GetCities()
        {
            var result = CityDataStore.Current.Cities;
            return Ok(result);
        }
    }
}