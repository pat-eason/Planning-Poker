using System.ComponentModel.DataAnnotations;

namespace PlanningPoker.Core.Entities
{
    public class SessionTask : EntityBase
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string CreatedBy { get; set; }

        public bool IsCompleted { get; set; }

        public DateTimeOffset? CompletedAt { get; set; }

        public Guid SessionId { get; set; }
        public virtual Session Session { get; set; }
    }
}
