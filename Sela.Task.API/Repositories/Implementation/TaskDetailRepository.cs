using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Sela.Task.API.Data;
using Sela.Task.API.Exceptions;
using Sela.Task.API.Models.Domain;
using Sela.Task.API.Repositories.Interface;
//using Sela.Task.API.Exceptions;
using System.Data;
using System.Drawing;

namespace Sela.Task.API.Repositories.Implementation
{
    public class TaskDetailRepository : ITaskDetailRepository
    {
        private readonly TaskDetailDbContext taskDetailDbContext;

        public TaskDetailRepository(TaskDetailDbContext taskDetailDbContext)
        {
            this.taskDetailDbContext = taskDetailDbContext;
        }

        public async Task<List<TaskDetail>> GetAllAsync()
        {
            return await taskDetailDbContext.TaskDetails.ToListAsync();
        }

        public async Task<TaskDetail?> GetByIdAsync(Guid id)
        {
            return await taskDetailDbContext.TaskDetails.FirstOrDefaultAsync(taskDetail => taskDetail.Id == id);
        }

        public async Task<TaskDetail> CreateAsync(TaskDetail taskInfo)
        {
            var exists = taskDetailDbContext.TaskDetails.Any(taskDetail => taskDetail.Title == taskInfo.Title);

            if (exists)
            {
                throw new DuplicateTaskDetailException("Task with same title is already exists");
            }

            await taskDetailDbContext.TaskDetails.AddAsync(taskInfo);
            await taskDetailDbContext.SaveChangesAsync();
            return taskInfo;
        }

        public async Task<TaskDetail?> DeleteAsync(Guid id)
        {
            var existingTaskDetail = await taskDetailDbContext.TaskDetails.FirstOrDefaultAsync(x => x.Id == id);

            if (existingTaskDetail == null)
            {
                return null;
            }

            taskDetailDbContext.TaskDetails.Remove(existingTaskDetail);
            await taskDetailDbContext.SaveChangesAsync();
            return existingTaskDetail;
        }

        public async Task<TaskDetail?> UpdateAsync(Guid id, TaskDetail taskDetail)
        {
            var existingTaskDetail = await taskDetailDbContext.TaskDetails.FirstOrDefaultAsync(x => x.Id == id);

            if (existingTaskDetail == null)
            {
                return null;
            }

            existingTaskDetail.Title = taskDetail.Title;
            existingTaskDetail.Status = taskDetail.Status;
            existingTaskDetail.Description = taskDetail.Description;

            await taskDetailDbContext.SaveChangesAsync();
            return existingTaskDetail;
        }
    }
}
