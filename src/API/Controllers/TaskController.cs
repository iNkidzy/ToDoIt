using System;
using System.Collections.Generic;
using BLL;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [Produces("application/json")] //
    [ApiController]
    [Route("[controller]")]
    public class TaskController : Controller
    {
        readonly ITaskService _taskService;
        
        public TaskController(ITaskService taskService)
        {
            
            _taskService = taskService;
        }
        [HttpGet]
        public ActionResult<List<Task>> Get()
        
        {
            Console.Out.WriteLine("First display of filenames to the console:");
            return _taskService.GetTasks();
        }
        
        [HttpPost]
        public Task Post(Task task)
        {
            return _taskService.Create(task);
        }
        
        [HttpPut]
        public Task Put(int id, Task taskUpdate)
        {
            return _taskService.Update(id, taskUpdate);
        }
        
        
        [HttpDelete]
        public Task Delete(int id)
        {
            return _taskService.Delete(id);
        }
    }
}