using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL
{
    public class TodoContext : DbContext
    {
        public static DbContextOptions<TodoContext>dbContextOptions { get; }
        public static string DatabaseConnectionString = "Server=mysql-db;Database=Todoit;UID=sa;PWD=HelloW0rld;";
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Assignee> Assignees { get; set; }

        public TodoContext()
        { }

        public TodoContext(DbContextOptions<TodoContext> config) : base(config)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConnectionString); //
        }
    }
}