using System.ComponentModel.DataAnnotations;

namespace PlanningPoker.Core.Entities
{
    public class SessionTaskVote : EntityBase
    {
        [Required]
        [Range(0,10)]
        public int Value { get; set; }

        [Required]
        [EmailAddress]
        public string CreatedBy { get; set; }

        public Guid SessionTaskId { get; set; }
        public virtual SessionTask SessionTask { get; set; }
    }
}
