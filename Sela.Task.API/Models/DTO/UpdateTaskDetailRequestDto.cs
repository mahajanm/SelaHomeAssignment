using System.ComponentModel.DataAnnotations;

namespace Sela.Task.API.Models.DTO
{
    public class UpdateTaskDetailRequestDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
