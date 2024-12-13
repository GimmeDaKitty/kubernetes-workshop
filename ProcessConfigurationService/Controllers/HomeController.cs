using Microsoft.AspNetCore.Mvc;

namespace ProcessConfigurationService.Controllers
{   
    [ApiController]
    [Route("/api/home")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(new {
                message1 = "This is the process configuration service",
                message2 = "Pinneapple belongs on pizza"
            });
        }
    }
}