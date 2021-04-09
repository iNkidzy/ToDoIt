using System.Collections.Generic;
using System.Linq;
using BLL.DomainService;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL.Repositories
{
    public class TaskRepo : ITaskRepo
    {
        private TodoContext _ctx;

        public TaskRepo(TodoContext ctx)
        {
            _ctx = ctx;
        }

        public Task Create(Task task)
        {
            Task t = _ctx.Tasks.Add(task).Entity;
            _ctx.SaveChanges();
            return t;
        }

        public Task Delete(int id)
        {
            Task tas = FindById(id);
            _ctx.Attach(tas).State = EntityState.Deleted;
            _ctx.SaveChanges();
            return tas;
        }

        public Task FindById(int id)
        {
            return _ctx.Tasks.Include(c => c.Assignee)
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Task> GetTask()
        {
            return _ctx.Tasks.Include(c => c.Assignee).ToList();
        }

        public Task Update(int id, Task taskUpdate)
        {
            var taskUp = FindById(id);
            taskUp.Description = taskUpdate.Description;
            taskUp.DueDate = taskUpdate.DueDate;
            taskUp.Assignee = taskUpdate.Assignee;
            taskUp.IsCompleted = taskUpdate.IsCompleted;

            _ctx.Attach(taskUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();

            return taskUpdate;

        }
    }
}