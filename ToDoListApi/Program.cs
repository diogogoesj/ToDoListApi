using Microsoft.EntityFrameworkCore;
using ToDoListApi.Data;
using ToDoListApi.Repository;
using ToDoListApi.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string? myDbConnection = builder.Configuration.GetConnectionString("MyDbConnection");

builder.Services.AddDbContext<ToDoListDatabase>(options =>
                    options.UseMySql(myDbConnection,
                    ServerVersion.AutoDetect(myDbConnection)));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
