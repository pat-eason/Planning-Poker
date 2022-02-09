using System.ComponentModel.DataAnnotations;

namespace PlanningPoker.Api.ViewModels.Request
{
    public class VoteForTaskRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(0,8)]
        public int Value { get; set; }
    }
}
