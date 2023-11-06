using System.Text.Json.Serialization;

namespace ToDoListApi.Models
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public TaskStatus StatusTask { get; set; }
        public int? UserId { get; set; }
        public virtual UserModel? User { get; set; }
    }
}
