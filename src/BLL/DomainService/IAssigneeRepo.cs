using System.Collections.Generic;
using Model;

namespace BLL.DomainService
{
    public interface IAssigneeRepo
    {
        Assignee Create(Assignee assignee);
        Assignee Delete(int id);
        Assignee FindById(int id);
        IEnumerable<Assignee> GetAssignee();
    }
}