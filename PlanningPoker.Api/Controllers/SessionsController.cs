using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PlanningPoker.Api.Hubs;
using PlanningPoker.Api.Repository;
using PlanningPoker.Api.ViewModels.Request;
using PlanningPoker.Core.Entities;

namespace PlanningPoker.Api.Controllers
{
    public class SessionsController : ApiControllerV1Base
    {
        private readonly ISessionsRepository _sessionsRepository;
        private readonly ISessionTasksRepository _sessionTasksRepository;
        private readonly ISessionTaskVotesRepository _sessionTaskVotesRepository;
        private readonly IHubContext<SessionHub> _sessionHubContext;

        public SessionsController(
            ILogger<SessionsController> logger,
            ISessionsRepository sessionsRepository,
            ISessionTasksRepository sessionTasksRepository,
            ISessionTaskVotesRepository sessionTaskVotesRepository,
            IHubContext<SessionHub> sessionHubContext
        ) : base(logger)
        {
            _sessionsRepository = sessionsRepository;
            _sessionTasksRepository = sessionTasksRepository;
            _sessionTaskVotesRepository = sessionTaskVotesRepository;
            _sessionHubContext = sessionHubContext;
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

        [HttpPost("vote/{id:Guid}")]
        public async Task<IActionResult> Vote(VoteForTaskRequest request, Guid id)
        {
            var session = await _sessionsRepository.GetOneAsync(id);
            if (session == null)
            {
                return NotFound($"Could not find Session with Id [{id}]");
            }

            var currentSessionTask = await _sessionTasksRepository.GetCurrentTaskAsync(session);
            if (currentSessionTask == null)
            {
                return NotFound($"Could not find Task to cast Vote for Session with Id [{session.Id}]");
            }

            var sessionTaskVote = await _sessionTaskVotesRepository.CreateOrUpdateVoteForSessionTask(
                currentSessionTask,
                request.Email,
                request.Value
            );

            await _sessionHubContext.Clients.Groups($"session_{session.Id}").SendAsync(
                SessionHubEvents.RECEIVE_VOTE,
                new
                {
                    CreatedBy = sessionTaskVote.CreatedBy,
                    Id = sessionTaskVote.Id,
                    Value = sessionTaskVote.Value
                }
            );

            return NoContent();
        }
    }
}
