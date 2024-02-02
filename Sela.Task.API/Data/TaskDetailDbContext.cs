using Microsoft.EntityFrameworkCore;
using Sela.Task.API.Models.Domain;

namespace Sela.Task.API.Data
{
    public class TaskDetailDbContext : DbContext
    {
        public TaskDetailDbContext (DbContextOptions<TaskDetailDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskDetail> TaskDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //we can add seeded data here if required.
        }
    }
}
