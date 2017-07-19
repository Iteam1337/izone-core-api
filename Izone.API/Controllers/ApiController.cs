using Microsoft.AspNetCore.Mvc;

namespace Izone.API.Controllers
{
    [Route("/")]
    public class ApiController : Controller
    {
        [HttpGet]
        public string Index()
        {
            return "IZONE CORE API";
        }
    }
}
