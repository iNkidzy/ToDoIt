using System;
using System.Collections.Generic;
using BLL;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssigneeController : Controller
    {
        readonly IAssigneeService _assigneeService;
        public AssigneeController(IAssigneeService assigneeService)
        {
            _assigneeService = assigneeService;
        }
        [HttpGet]
        public IEnumerable<Assignee> Get()
        {
            return _assigneeService.GetAssignees();
        }
        
        [HttpPost]
        public Assignee Post(Assignee assignee)
        {
            return _assigneeService.Create(assignee);
        }
        
        [HttpDelete]
        public Assignee Delete(int id)
        {
            return _assigneeService.Delete(id);
        }
    }
}