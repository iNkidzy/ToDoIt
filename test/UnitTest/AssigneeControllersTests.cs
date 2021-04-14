using System;
using BLL.ApplicationService;
using DAL;
using DAL.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using WebApi.Controllers;
using Xunit;

namespace UnitTest
{
    public class AssigneeControllersTests
    {
        private AssigneeService aService;
        private AssigneeRepo aRepo;
        public static DbContextOptions<TodoContext> dbContextOptions { get; }
        public static string DatabaseConnectionString = "Server=mysql-db;Database=Todoit;UID=sa;PWD=HelloW0rld;";

        static AssigneeControllersTests()
        {
            dbContextOptions = new DbContextOptionsBuilder<TodoContext>()
                                .UseSqlServer(DatabaseConnectionString)
                                .Options;
        }
        public AssigneeControllersTests()
        {
            var context = new TodoContext(dbContextOptions);
            DBInitializer db = new DBInitializer();
            db.SeedDB(context);

            aRepo = new AssigneeRepo(context);
            aService = new AssigneeService(aRepo);
        }


        //TestCase1: FindTask by id succesfully
        [Fact]
        public void Task_FindTaskById_Return_OkResult()
        {
            //Arrange
            var controller = new AssigneeController(aService);
            var assigneeId = 2;

            //Act
            var data = controller.Get(assigneeId);

            //Assert
            Assert.IsType<OkObjectResult>(data);

        }


        //TestCase2: Get All Assignees succesfully
        [Fact]
        public void Task_GetTasks_Return_OkResult()
        {
            //Arrange
            var controller = new AssigneeController(aService);

            //Act
            var data = controller.Get();

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        //TestCase3: Create Assignee
        [Fact]
        public void Create_ValidData_Return_OkResult()
        {
            //Arrange
            var controller = new AssigneeController(aService);
            var assignee = new Assignee() { Name = "Kiki" };

            //Act
            var data = controller.Post(assignee);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }


        //TestCase4: Delete succesfully
        [Fact]
        public void Task_Delete_Return_OkResult()
        {
            //Arrange
            var controller = new AssigneeController(aService);
            var assigneeId = 2;

            //Act
            var data = controller.Delete(assigneeId);

            //Assert
            Assert.IsType<OkResult>(data);
        }

    }
}
