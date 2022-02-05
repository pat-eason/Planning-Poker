using Microsoft.AspNetCore.Mvc;
using PlanningPoker.Api.ViewModels.Response;

namespace PlanningPoker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiControllerV1Base : ControllerBase
    {
        protected readonly ILogger _logger;

        public ApiControllerV1Base(ILogger logger)
        {
            _logger = logger;
        }

        public IActionResult OkResponseEnvelope<T>(T data)
        {
            var responseEnvelope = new ResponseEnvelope<T>(data);
            return Ok(responseEnvelope);
        }
    }
}
