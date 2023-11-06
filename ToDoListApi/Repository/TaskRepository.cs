using Microsoft.EntityFrameworkCore;
using ToDoListApi.Data;
using ToDoListApi.Models;
using ToDoListApi.Repository.Interfaces;

namespace ToDoListApi.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ToDoListDatabase _taskDatabase;
        public TaskRepository(ToDoListDatabase taskDatabase) { _taskDatabase = taskDatabase; }

        public async Task<List<TaskModel>> GetAll()
        {
            return await _taskDatabase.Tasks.Include(userTask => userTask.User).ToListAsync();
        }

        public async Task<TaskModel> GetById(int id)
        {
            return await _taskDatabase.Tasks.Include(userTask => userTask.User).FirstOrDefaultAsync(taskUnkown => taskUnkown.TaskId == id);
        }

        public async Task<TaskModel> Add(TaskModel task)
        {
            await _taskDatabase.Tasks.AddAsync(task);
            await _taskDatabase.SaveChangesAsync();

            return task;
        }
        public async Task<TaskModel> Update(TaskModel task, int id)
        {
            TaskModel taskById = await GetById(id);

            if (taskById == null)
            {
                throw new Exception($"Tarefa de id: {id} não encontrada");
            }

            taskById.TaskName = task.TaskName;
            taskById.TaskDescription = task.TaskDescription;
            taskById.StatusTask = task.StatusTask;
            taskById.UserId = task.UserId;

            _taskDatabase.Tasks.Update(taskById);
            await _taskDatabase.SaveChangesAsync();

            return taskById;
        }

        public async Task<bool> Delete(int id)
        {
            TaskModel taskById = await GetById(id);

            if (taskById == null)
            {
                throw new Exception($"Tarefa de id: {id} não encontrada");
            }

            _taskDatabase.Tasks.Remove(taskById);
            await _taskDatabase.SaveChangesAsync();

            return true;
        }


    }
}
