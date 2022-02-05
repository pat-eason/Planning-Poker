using Microsoft.AspNetCore.Mvc;
using PlanningPoker.Api.Repository;

namespace PlanningPoker.Api.Controllers
{
    public class TasksController : ApiControllerV1Base
    {
        private readonly ISessionTasksRepository _sessionTasksRepository;

        public TasksController(
            ILogger<TasksController> logger,
            ISessionTasksRepository sessionTasksRepository
        ) : base(logger)
        {
            _sessionTasksRepository = sessionTasksRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var sessionTasks = await _sessionTasksRepository.GetAllAsync();
            return OkResponseEnvelope(sessionTasks);
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return OkResponseEnvelope("test");
        }

        [HttpPut]
        public async Task<IActionResult> Update()
        {
            return OkResponseEnvelope("test");
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var sessionTask = await _sessionTasksRepository.GetOneAsync(id);
            if (sessionTask == null)
            {
                return NotFound();
            }
            return OkResponseEnvelope(sessionTask);
        }
    }
}
