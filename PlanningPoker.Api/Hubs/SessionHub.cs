using Microsoft.AspNetCore.SignalR;
using PlanningPoker.Core.Entities;

namespace PlanningPoker.Api.Hubs
{
    public class SessionHub : Hub, ISessionHub
    {
        private List<string> sessionGroups = new List<string>();

        // @TODO clear groups
        public async Task ClearUserSessions()
        {
            sessionGroups.ForEach(async group =>
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, group);
            });
        }
        public async Task EndSession(Session session)
        {
            var groupName = GenerateGroupName(session.Id);
            await Clients.Group(groupName).SendAsync(SessionHubEvents.END_SESSION);
        }

        public async Task EndSessionTask(SessionTask sessionTask)
        {
            var groupName = GenerateGroupName(sessionTask.SessionId);
            await Clients.Group(groupName).SendAsync(SessionHubEvents.END_SESSION_TASK);
        }

        public async Task JoinSessionGroup(Guid sessionId, string email, string name)
        {
            var groupName = GenerateGroupName(sessionId);
            if (!sessionGroups.Any(x => x == groupName))
            {
                sessionGroups.Add(groupName);
            }
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupName}.");
        }

        public async Task NewSessionTask(SessionTask sessionTask)
        {
            var groupName = GenerateGroupName(sessionTask.SessionId);
            var group = Clients.Group(groupName);
            await group.SendAsync(SessionHubEvents.RECEIVE_SESSION_TASK, "test value");
        }
        
        public async Task NewSessionTaskVote(SessionTaskVote sessionVote)
        {
            var groupName = GenerateGroupName(sessionVote.SessionTask.SessionId);
            await Clients.Group(groupName).SendAsync(SessionHubEvents.RECEIVE_VOTE, sessionVote);
        }
    
        protected string GenerateGroupName(Guid sessionId)
        {
            return $"session_{sessionId}";
        }
    }
}
