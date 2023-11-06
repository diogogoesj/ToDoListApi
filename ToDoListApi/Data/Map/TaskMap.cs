using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoListApi.Models;

namespace ToDoListApi.Data.Map
{
    public class TaskMap : IEntityTypeConfiguration<TaskModel>
    {
        public void Configure(EntityTypeBuilder<TaskModel> builder)
        {
            builder.HasKey(task => task.TaskId);
            builder.Property(task => task.TaskName).IsRequired().HasMaxLength(255);
            builder.Property(task => task.TaskDescription).HasMaxLength(1000);
            builder.Property(task => task.StatusTask).IsRequired();
            builder.Property(task => task.UserId);
            builder.HasOne(task => task.User);


        }
    }
}
