using Microsoft.AspNetCore.Mvc;

namespace PlanningPoker.Api.Controllers
{
    public class VotesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
