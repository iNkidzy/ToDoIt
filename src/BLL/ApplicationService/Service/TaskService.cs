using System;
using System.Collections.Generic;
using System.Linq;
using BLL.DomainService;
using Model;

namespace BLL.ApplicationService
{
    public class TaskService : ITaskService
    {
        readonly ITaskRepo _taskRepo;

        public TaskService(ITaskRepo taskRepo)
        {
            _taskRepo = taskRepo;
        }

        public Task Create(Task task)
        {
            return _taskRepo.Create(task);
        }

        public Task CreateTask(string description, bool isCompleted, Assignee assignee, DateTime dueDate)
        {
            var task = new Task()
            {
                Description = description,
                DueDate = dueDate,
                IsCompleted = isCompleted,
                Assignee = assignee
            };

            return task;
        }

        public Task Delete(int id)
        {
            return _taskRepo.Delete(id);
        }

        public Task FindById(int id)
        {
            return _taskRepo.FindById(id);
        }

        public List<Task> GetTasks()
        {
            return _taskRepo.GetTask().ToList();
        }
        //Check
        public Task Update(int id,Task taskUpdate)
        {
            return _taskRepo.Update(id,taskUpdate);
            
        }
    }
}