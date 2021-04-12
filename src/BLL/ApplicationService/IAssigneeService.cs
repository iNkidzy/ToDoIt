using System.Collections.Generic;
using Model;

namespace BLL
{
    public interface IAssigneeService
    {
        Assignee Create(Assignee assignee);

        Assignee FindById(int id);

        List<Assignee> GetAssignees();

        Assignee Delete(int id);

    }
}