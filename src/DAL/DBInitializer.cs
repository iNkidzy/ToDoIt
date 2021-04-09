using System;
using Model;

namespace DAL
{
    public class DBInitializer
    {
        
        public void SeedDB(TodoContext ctx)
        {
            Assignee as1 = new Assignee()
            {
                Name = "Jerry",

            };
             ctx.Assignees.Add(as1);

            Assignee as2 = new Assignee()
            {
                Name = "Lala",

            };
            ctx.Assignees.Add(as2);

            Assignee as3 = new Assignee()
            {
                Name = "Kiki",

            };
            ctx.Assignees.Add(as3);

            Assignee as4 = new Assignee()
            {
                Name = "John",

            };
            ctx.Assignees.Add(as4);

            Task task1 = new Task()
            {
                Description = "Project",
                DueDate = DateTime.Parse("10/03/2021"),
                IsCompleted = true,
                Assignee = as4,
            };
            ctx.Tasks.Add(task1);

            Task task2 = new Task()
            {
                Description = "FailedProject",
                DueDate = DateTime.Parse("10/03/2021"),
                IsCompleted = false,
                Assignee = as3,
            };
            ctx.Tasks.Add(task2);

            Task task3 = new Task()
            {
                Description = "Project",
                DueDate = DateTime.Parse("10/03/2021"),
                IsCompleted = true,
                Assignee = as2,
            };
            ctx.Tasks.Add(task3);

            Task task4 = new Task()
            {
                Description = "Project",
                DueDate = DateTime.Parse("10/03/2021"),
                IsCompleted = true,
                Assignee = as1,
            };
            ctx.Tasks.Add(task4);

            ctx.Assignees.AddRange(as3, as4, as1, as2);
            ctx.Tasks.AddRange(task1, task2, task3, task4);
            ctx.SaveChanges();
        }
    }
}