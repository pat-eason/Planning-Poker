using Microsoft.AspNetCore.Mvc;
using PlanningPoker.Api.Repository;
using PlanningPoker.Api.ViewModels.Request;
using PlanningPoker.Core.Entities;

namespace PlanningPoker.Api.Controllers
{
    public class SessionsController : ApiControllerV1Base
    {
        private readonly ISessionsRepository _sessionsRepository;

        public SessionsController(
            ILogger<SessionsController> logger,
            ISessionsRepository sessionsRepository
        ) : base(logger)
        {
            _sessionsRepository = sessionsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var sessions = await _sessionsRepository.GetAllAsync();
            return OkResponseEnvelope(sessions);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSessionRequest request)
        {
            var session = new Session
            {
                Name = request.Name,
                IsPrivate = request.IsPrivate ?? false,
                Password = request.Password,
                CreatedBy = request.Email
            };
            await _sessionsRepository.CreateAsync(session);
            return OkResponseEnvelope(session);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateSessionRequest request)
        {
            var session = await _sessionsRepository.GetOneAsync(request.Id);
            if (session == null)
            {
                return NotFound();
            }
            session.Name = request.Name;
            session.Password = request.Password;
            session.IsPrivate = request.IsPrivate ?? false;
            await _sessionsRepository.UpdateAsync(session);
            return OkResponseEnvelope(session);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var session = await _sessionsRepository.GetOneAsync(id);
            if (session == null)
            {
                return NotFound();
            }
            return OkResponseEnvelope(session);
        }
    }
}
