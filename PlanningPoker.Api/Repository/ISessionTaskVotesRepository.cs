using PlanningPoker.Core.Entities;

namespace PlanningPoker.Api.Repository
{
    public interface ISessionTaskVotesRepository : IRepositoryBase<SessionTaskVote>
    {
        public Task<SessionTaskVote> CreateOrUpdateVoteForSessionTask(SessionTask sessionTask, string email, int vote);
        public Task<SessionTaskVote> CreateOrUpdateVoteForSessionTask(Guid id, string email, int vote);
    }
}
