using System;
using System.Collections.Generic;
using Model;

namespace BLL
{
    public interface ITaskService
    {
        Task CreateTask(string Description, bool IsCompleted, Assignee assignee, DateTime dueDate);

        Task Create(Task task);

        Task FindById(int id);

        Task Update(int id, Task taskUpdate);

        Task Delete(int id);

        List<Task> GetTask();

    }
}