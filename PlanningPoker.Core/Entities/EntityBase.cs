using System.ComponentModel.DataAnnotations;

namespace PlanningPoker.Core.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
