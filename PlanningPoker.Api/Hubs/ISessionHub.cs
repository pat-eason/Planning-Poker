using PlanningPoker.Core.Entities;

namespace PlanningPoker.Api.Hubs
{
    public interface ISessionHub
    {
        Task ClearUserSessions();
        Task EndSession(Session session);
        Task EndSessionTask(SessionTask sessionTask);
        Task JoinSessionGroup(Guid sessionId, string email, string name);
        Task NewSessionTask(SessionTask sessionTask);
        Task NewSessionTaskVote(SessionTaskVote sessionTaskVote);
    }
}
