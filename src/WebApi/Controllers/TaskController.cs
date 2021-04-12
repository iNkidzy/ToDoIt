using System;
using System.Collections.Generic;
using System.Linq;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebApi.Controllers
{
    //[Produces("application/json")] //
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        
        [HttpGet]
        public ActionResult<List<Task>> Get()
        {
            return _taskService.GetTasks();
        }
        /*
        // GET: api/Task
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_taskService.GetTask());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
*/
     
        // GET: api/Task/5
        [HttpGet("{id}")]
        public ActionResult<Task> Get(int id)
        {
            try
            {
                return Ok(_taskService.FindById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        // POST: api/Task
        [HttpPost]
        public ActionResult Post([FromBody] Task task)
        {
            try
            {

                if (task != null)
                {
                    return Ok(_taskService.Create(task));
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        // PUT: api/Task/5
        [HttpPut("{id}")]
        public ActionResult Put(int id,[FromBody] Task taskUpdate)
        {
            try
            {
                if (id != taskUpdate.Id)
                {
                    return BadRequest();
                }

                return Ok(_taskService.Update(id, taskUpdate));
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(e.Message);
            }

        }

        // DELETE: api/Task/5
        [HttpDelete("{id}")]
        public ActionResult<Task> Delete(int id)
        {
            try
            {
                return Ok(_taskService.Delete(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
    }
}
