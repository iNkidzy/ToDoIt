using System.Collections.Generic;
using System.Linq;
using BLL.DomainService;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL.Repositories
{
    public class AssigneeRepo : IAssigneeRepo
    {
        private readonly TodoContext _ctx;

        public AssigneeRepo(TodoContext ctx)
        {
            _ctx = ctx;
        }

        public Assignee Create(Assignee assignee)
        {
            _ctx.Attach(assignee).State = EntityState.Added;
            _ctx.SaveChanges();
            return assignee;
        }

        public Assignee Delete(int id)
        {
            Assignee aDelete = FindById(id);
            _ctx.Attach(aDelete).State = EntityState.Deleted;
            _ctx.SaveChanges();
            return aDelete;
        }

        public Assignee FindById(int id)
        {
            return _ctx.Assignees.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Assignee> GetAssignee()
        {
            return _ctx.Assignees;
        }
    }
}