using System.ComponentModel;

namespace ToDoListApi.Enums
{
    public enum TaskStatus
    {
        [Description("Task not started")]
        NotStarted = 1,
        [Description("Task in progress")]
        InProgress = 2,
        [Description("Task completed")]
        Completed = 3
    }
}
