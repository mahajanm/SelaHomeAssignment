using Sela.Task.API.Models.Enum;

namespace Sela.Task.API.Models.Domain
{
    public class TaskDetail
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Enum.TaskStatus Status { get; set; }
        public DateTime DueDate { get; set; }
    }
}
