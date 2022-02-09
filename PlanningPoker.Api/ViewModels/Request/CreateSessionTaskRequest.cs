using System.ComponentModel.DataAnnotations;

namespace PlanningPoker.Api.ViewModels.Request
{
    public class CreateSessionTaskRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public Guid SessionId { get; set; }
    }
}
