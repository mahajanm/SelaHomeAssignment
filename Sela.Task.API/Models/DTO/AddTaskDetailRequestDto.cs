using System.ComponentModel.DataAnnotations;

namespace Sela.Task.API.Models.DTO
{
    public class AddTaskDetailRequestDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public DateTime DueDate { get; set; }
    }
}
