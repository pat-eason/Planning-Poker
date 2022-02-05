using System.ComponentModel.DataAnnotations;

namespace PlanningPoker.Api.ViewModels.Request
{
    public class UpdateSessionRequest
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public bool? IsPrivate { get; set; }

        public string? Password { get; set; }
    }
}
