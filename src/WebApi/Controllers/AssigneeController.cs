using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebApi.Controllers
{
    [Route("api/assaignee")]
    [ApiController]
    public class AssigneeController : ControllerBase
    {
        private readonly IAssigneeService _assigneeService;

        public AssigneeController(IAssigneeService assigneeService)
        {
            _assigneeService = assigneeService;
        }
        // GET: api/Assignee
        [HttpGet]
        public IEnumerable<Assignee> Get()
        {
        
         return _assigneeService.GetAssignees();
            
            
        }

        // GET: api/Assignee/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_assigneeService.FindById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // POST: api/Assignee/5
        [HttpPost]
        public Assignee Post(Assignee assignee)
        {
            return _assigneeService.Create(assignee);
        }

        // DELETE: api/Assignee/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_assigneeService.Delete(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            }
    }
}
