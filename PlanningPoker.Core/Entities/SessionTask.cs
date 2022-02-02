namespace PlanningPoker.Core.Entities
{
    public class SessionTask : EntityBase
    {
        public string Name { get; set; } = "";

        public Guid SessionId { get; set; }
        public virtual Session Session { get; set; }
    }
}
