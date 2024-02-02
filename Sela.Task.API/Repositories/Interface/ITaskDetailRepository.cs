using Sela.Task.API.Models.Domain;


namespace Sela.Task.API.Repositories.Interface
{
    public interface ITaskDetailRepository
    {
        Task<List<TaskDetail>> GetAllAsync();

        Task<TaskDetail?> GetByIdAsync(Guid id);

        Task<TaskDetail> CreateAsync(TaskDetail taskDetail);

        Task<TaskDetail?> UpdateAsync(Guid id, TaskDetail taskDetail);

        Task<TaskDetail?> DeleteAsync(Guid id);
    }
}
