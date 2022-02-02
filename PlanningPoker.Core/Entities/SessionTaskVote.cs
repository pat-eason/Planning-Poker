namespace PlanningPoker.Core.Entities
{
    public class SessionTaskVote : EntityBase
    {
        public int Value { get; set; }

        public Guid SessionTaskId { get; set; }
        public virtual SessionTask SessionTask { get; set; }
    }
}
