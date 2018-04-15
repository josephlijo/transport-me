using Microsoft.AspNetCore.Mvc;

namespace TransportMe.Places.API.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        [HttpGet()]
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}
