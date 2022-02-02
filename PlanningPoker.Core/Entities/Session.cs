namespace PlanningPoker.Core.Entities
{
    public class Session : EntityBase
    {
        public string Name { get; set; } = "";
        public bool IsPrivate { get; set; } = false;
        public string Password { get; set; } = "";

        public virtual List<SessionTask> SessionTasks { get; set; }
    }
}
