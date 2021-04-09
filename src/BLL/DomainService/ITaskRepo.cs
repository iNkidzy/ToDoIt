using System.Collections.Generic;
using Model;

namespace BLL.DomainService
{
    public interface ITaskRepo
    {
        Task Create(Task task);
        Task FindById(int id);
        Task Update(int id, Task taskUpdate);
        Task Delete(int id);
        IEnumerable<Task> GetTask();

    }
}