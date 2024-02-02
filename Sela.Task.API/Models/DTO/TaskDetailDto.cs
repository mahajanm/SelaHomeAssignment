namespace Sela.Task.API.Models.DTO
{
    public class TaskDetailDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Enum.TaskStatus Status { get; set; }
        public DateTime DueDate { get; set; }
    }
}
