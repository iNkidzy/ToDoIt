using System;
using BLL.ApplicationService;
using DAL;
using DAL.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Model;
using WebApi.Controllers;
using Xunit;

namespace UnitTest
{
    public class TaskControllersTests
    {
        private TaskService taskService;
        private TaskRepo tRepository;
        public static DbContextOptions<TodoContext>dbContextOptions { get; }
        public static string DatabaseConnectionString = "Server=mysql-db;Database=Todoit;UID=sa;PWD=HelloW0rld;";

        static TaskControllersTests()
        {
            dbContextOptions = new DbContextOptionsBuilder<TodoContext>()
                                .UseSqlServer(DatabaseConnectionString)
                                .Options;
        }

        public TaskControllersTests()
        {
            var context = new TodoContext(dbContextOptions);
            DBInitializer db = new DBInitializer();
            db.SeedDB(context);

            tRepository = new TaskRepo(context);
            taskService = new TaskService(tRepository);

        }

        //TestCase1: FindTask by id succesfully
         [Fact]
         public void Task_FindTaskById_Return_OkResult()
         {
            //Arrange
            var controller = new TaskController(taskService);
            var taskId = 2;

            //Act
            var data =  controller.Get(taskId);

            //Assert
            Assert.IsType<OkObjectResult>(data);


         }
        //TestCase2: Get All Tasks succesfully
        [Fact]
        public void Task_GetTasks_Return_OkResult()
        {
            //Arrange
            var controller = new TaskController(taskService);

            //Act
            var data =  controller.Get();

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        //TestCase3: Create Task
        [Fact]
        public void Create_ValidData_Return_OkResult()
        {
            //Arrange
            var controller = new TaskController(taskService);
            var task = new Task() { Description ="Finnish presentation", IsCompleted =true, DueDate = DateTime.Now };

            //Act
            var data = controller.Post(task);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        //TestCase4: Update by id succesfully
        [Fact]
        public void Task_Update_ValidData_Return_OkResult()
        {
            //Arrange
            var controller = new TaskController(taskService);
            var id = 2;

            //Act
            var existingTask = controller.Get(id);
            var okResult = existingTask.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<Task>().Subject;

            var task = new Task();
            task.Assignee = result.Assignee;
            task.Description = result.Description;
            task.IsCompleted = result.IsCompleted;
            task.DueDate = result.DueDate;

            var updatedData = controller.Put(id, task);

            //Assert
            Assert.IsType<OkResult>(updatedData);
        }

        //TestCase5: Delete succesfully
        [Fact]
        public void Task_Delete_Return_OkResult()
        {
            //Arrange
            var controller = new TaskController(taskService);
            var taskId = 2;

            //Act
            var data = controller.Delete(taskId);

            //Assert
            Assert.IsType<OkResult>(data);
        }

    }
}