using Microsoft.EntityFrameworkCore;
using PlanningPoker.Core;
using PlanningPoker.Core.Entities;

namespace PlanningPoker.Api.Repository
{
    public class SessionTasksRepository : ISessionTasksRepository
    {
        private readonly ILogger<SessionTasksRepository> _logger;
        private readonly PlanningPokerDbContext _dbContext;

        public SessionTasksRepository(
            ILogger<SessionTasksRepository> logger,
            PlanningPokerDbContext dbContext
        )
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<SessionTask> CreateAsync(SessionTask sessionTask)
        {
            sessionTask.Id = Guid.NewGuid();
            sessionTask.CreatedAt = DateTimeOffset.Now;
            sessionTask.UpdatedAt = DateTimeOffset.Now;
            await _dbContext.SessionTasks.AddAsync(sessionTask);
            await _dbContext.SaveChangesAsync();
            return sessionTask;
        }

        public async Task DeleteAsync(SessionTask sessionTask)
        {
            _dbContext.SessionTasks.Remove(sessionTask);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var sessionTask = await _dbContext.SessionTasks.FindAsync(id);
            if (sessionTask != null)
            {
                await DeleteAsync(sessionTask);
            }
        }

        public async Task<List<SessionTask>> GetAllAsync()
        {
            return await _dbContext.SessionTasks.ToListAsync();
        }

        public async Task<SessionTask?> GetCurrentTaskAsync(Session session)
        {
            return await GetCurrentTaskAsync(session.Id);
        }

        public async Task<SessionTask?> GetCurrentTaskAsync(Guid sessionId)
        {
            return await _dbContext.SessionTasks
                .OrderByDescending(x => x.CreatedAt)
                .FirstOrDefaultAsync(x => x.SessionId == sessionId && !x.IsCompleted);
        }

        public async Task<SessionTask?> GetOneAsync(Guid id)
        {
            return await _dbContext.SessionTasks.FindAsync(id);
        }

        public async Task<SessionTask> UpdateAsync(SessionTask sessionTask)
        {
            sessionTask.UpdatedAt = DateTimeOffset.Now;
            _dbContext.SessionTasks.Update(sessionTask);
            await _dbContext.SaveChangesAsync();
            return sessionTask;
        }
    }
}
