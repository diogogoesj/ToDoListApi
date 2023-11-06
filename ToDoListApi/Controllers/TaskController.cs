using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Models;
using ToDoListApi.Repository.Interfaces;

namespace ToDoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetAll()
        {
            List<TaskModel> tasks = await _taskRepository.GetAll();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TaskModel>>> GetById(int id)
        {
            TaskModel task = await _taskRepository.GetById(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> Register([FromBody] TaskModel taskModel)
        {
            TaskModel task = await _taskRepository.Add(taskModel);

            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> Modify([FromBody] TaskModel taskModel, int id)
        {
            taskModel.TaskId = id;
            TaskModel task = await _taskRepository.Update(taskModel, id);

            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>> Clear(int id)
        {
            bool taskDeleted = await _taskRepository.Delete(id);

            return Ok(taskDeleted);
        }
    }
}
