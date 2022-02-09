using PlanningPoker.Core.Entities;

namespace PlanningPoker.Api.Repository
{
    public interface ISessionTasksRepository : IRepositoryBase<SessionTask>
    {
        Task<SessionTask?> GetCurrentTaskAsync(Session session);
        Task<SessionTask?> GetCurrentTaskAsync(Guid sessionId);
    }
}
