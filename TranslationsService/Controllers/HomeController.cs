using Microsoft.AspNetCore.Mvc;

namespace TranslationsService.Controllers
{   
    [ApiController]
    [Route("/api/home")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(new {
                message = "This is the translations service"
            });
        }
    }
}