using Microsoft.AspNetCore.Mvc;
using PlanningPoker.Api.Repository;
using PlanningPoker.Core.Entities;

namespace PlanningPoker.Api.Controllers
{
    public class SessionsController : Controller
    {
        private readonly ISessionsRepository _sessionsRepository;

        public SessionsController(ISessionsRepository sessionsRepository)
        {
            _sessionsRepository = sessionsRepository;
        }

        /// <summary>
        /// Retrieve all Sessions
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var sessions = await _sessionsRepository.GetAllAsync();
            return Ok(sessions);
        }

        /// <summary>
        /// Create a new Session
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<IActionResult> Create(Session session)
        {
            var createdSession = await _sessionsRepository.CreateAsync(session);
            return Ok(createdSession);
        }
    }
}
