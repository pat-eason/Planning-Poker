using System.ComponentModel.DataAnnotations;

namespace PlanningPoker.Api.ViewModels.Request
{
    public class CreateSessionRequest
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public bool? IsPrivate { get; set; }

        public string? Password { get; set; }
    }
}
