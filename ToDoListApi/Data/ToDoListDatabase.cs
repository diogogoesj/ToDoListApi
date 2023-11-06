using Microsoft.EntityFrameworkCore;
using ToDoListApi.Data.Map;
using ToDoListApi.Models;

namespace ToDoListApi.Data
{
    public class ToDoListDatabase : DbContext
    {
        public ToDoListDatabase(DbContextOptions<ToDoListDatabase> options) : base(options)
        {
            
        }
        
        public DbSet<UserModel> Users { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
