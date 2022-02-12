namespace PlanningPoker.Api.Hubs
{
    public class SessionHubEvents
    {
        public static string END_SESSION = "endSession";
        public static string END_SESSION_TASK = "endSessionTask";
        public static string RECEIVE_SESSION_TASK = "receiveSessionTask";
        public static string RECEIVE_VOTE = "receiveVote";
        public static string START_SESSION = "startSession";
    }
}
