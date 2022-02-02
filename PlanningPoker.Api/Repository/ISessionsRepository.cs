using PlanningPoker.Core.Entities;

namespace PlanningPoker.Api.Repository
{
    public interface ISessionsRepository
    {
        Task<List<Session>> GetAllAsync();
        Task<Session> CreateAsync(Session session);
    }
}
