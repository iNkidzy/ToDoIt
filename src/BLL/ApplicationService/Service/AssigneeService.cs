using System.Collections.Generic;
using System.Linq;
using BLL.DomainService;
using Model;

namespace BLL.ApplicationService
{
    public class AssigneeService: IAssigneeService
    {
        readonly IAssigneeRepo _aRepo;

        public AssigneeService(IAssigneeRepo aRepo)
        {
            _aRepo = aRepo;
        }

        public Assignee Create(Assignee assignee)
        {
            return _aRepo.Create(assignee);
        }

        public Assignee Delete(int id)
        {
            return _aRepo.Delete(id);
        }

        public Assignee FindById(int id)
        {
            return FindById(id);
        }

        public List<Assignee> GetAssignees()
        {
            return _aRepo.GetAssignee().ToList();
        }
    }
}