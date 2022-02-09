using Microsoft.EntityFrameworkCore;
using PlanningPoker.Core;
using PlanningPoker.Core.Entities;

namespace PlanningPoker.Api.Repository
{
    public class SessionTaskVotesRepository : ISessionTaskVotesRepository
    {
        private readonly ILogger<SessionTaskVotesRepository> _logger;
        private readonly PlanningPokerDbContext _dbContext;

        public SessionTaskVotesRepository(
            ILogger<SessionTaskVotesRepository> logger,
            PlanningPokerDbContext dbContext
        )
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Task<SessionTaskVote> CreateAsync(SessionTaskVote entity)
        {
            throw new NotImplementedException();
        }

        public async Task<SessionTaskVote> CreateOrUpdateVoteForSessionTask(SessionTask sessionTask, string email, int vote)
        {
            if (sessionTask.IsCompleted)
            {
                throw new Exception("Cannot set Votes for a Task that has already been completed");
            }

            var sessionTaskVote = await _dbContext.SessionTaskVotes
                .FirstOrDefaultAsync(x => x.SessionTaskId == sessionTask.Id && x.CreatedBy == email);
            if (sessionTaskVote != null && sessionTaskVote.CreatedBy != email)
            {
                throw new Exception("User cannot update Vote that they did not create");
            }

            if (sessionTaskVote == null)
            {
                sessionTaskVote = new SessionTaskVote();
            }

            var isFreshEntity = await _dbContext.SessionTaskVotes.AnyAsync(x => x.Id == sessionTaskVote.Id);
            sessionTaskVote.UpdatedAt = DateTime.UtcNow;
            sessionTaskVote.Value = vote;
            if (isFreshEntity) {
                sessionTaskVote.CreatedAt = DateTime.UtcNow;
                sessionTaskVote.CreatedBy = email;
                sessionTaskVote.SessionTaskId = sessionTaskVote.Id;
            }

            _dbContext.Entry(sessionTaskVote).State = isFreshEntity
                ? EntityState.Added
                : EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return sessionTaskVote;
        }

        public async Task<SessionTaskVote> CreateOrUpdateVoteForSessionTask(Guid id, string email, int vote)
        {
            var sessionTask = await _dbContext.SessionTasks.FirstOrDefaultAsync(x => x.Id == id);
            if (sessionTask == null)
            {
                throw new Exception("Task could not be found to cast Vote for");
            }
            return await CreateOrUpdateVoteForSessionTask(sessionTask, email, vote);
        }

        public Task DeleteAsync(SessionTaskVote entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SessionTaskVote>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SessionTaskVote?> GetOneAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<SessionTaskVote> UpdateAsync(SessionTaskVote entity)
        {
            throw new NotImplementedException();
        }
    }
}
