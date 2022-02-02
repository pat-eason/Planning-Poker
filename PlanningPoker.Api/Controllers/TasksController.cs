using Microsoft.AspNetCore.Mvc;

namespace PlanningPoker.Api.Controllers
{
    public class TasksController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
