using Microsoft.AspNetCore.Mvc;
using PlanningPoker.Api.Repository;
using PlanningPoker.Api.ViewModels.Request;
using PlanningPoker.Core.Entities;

namespace PlanningPoker.Api.Controllers
{
    public class TasksController : ApiControllerV1Base
    {
        private readonly ISessionsRepository _sessionsRepository;
        private readonly ISessionTasksRepository _sessionTasksRepository;

        public TasksController(
            ILogger<TasksController> logger,
            ISessionsRepository sessionsRepository,
            ISessionTasksRepository sessionTasksRepository
        ) : base(logger)
        {
            _sessionsRepository = sessionsRepository;
            _sessionTasksRepository = sessionTasksRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var sessionTasks = await _sessionTasksRepository.GetAllAsync();
            return OkResponseEnvelope(sessionTasks);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSessionTaskRequest request)
        {
            var session = await _sessionsRepository.GetOneAsync(request.SessionId);
            if (session == null)
            {
                return NotFound($"Could not find Session with Id {request.SessionId}");
            }

            var sessionTask = new SessionTask
            {
                CreatedBy = request.Email,
                Name = request.Name,
                Session = session,
            };

            var createdSessionTask = await _sessionTasksRepository.CreateAsync(sessionTask);
            return OkResponseEnvelope(createdSessionTask);
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
                return NotFound($"Could not find Session with Id {id}");
            }
            return OkResponseEnvelope(sessionTask);
        }
    }
}
