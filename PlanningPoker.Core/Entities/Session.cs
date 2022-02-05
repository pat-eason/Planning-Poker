using System.ComponentModel.DataAnnotations;

namespace PlanningPoker.Core.Entities
{
    public class Session : EntityBase
    {
        [Required]
        public string Name { get; set; }

        public bool IsPrivate { get; set; }

        public string? Password { get; set; }
        
        [Required]
        [EmailAddress]
        public string CreatedBy { get; set; }

        public virtual List<SessionTask> SessionTasks { get; set; }
    }
}
