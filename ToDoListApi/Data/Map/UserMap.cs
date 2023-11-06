using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoListApi.Models;

namespace ToDoListApi.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(user => user.UserId);
            builder.Property(user => user.UserName).IsRequired().HasMaxLength(255);
            builder.Property(user => user.UserEmail).IsRequired().HasMaxLength(150);
        }
    }
}
