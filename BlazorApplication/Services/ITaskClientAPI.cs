using BlazorApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApplication.Services
{
    public interface ITaskClientAPI
    {
        Task<List<TaskDto>> GetTaskList(TaskListSearch taskListSearch);

        Task<TaskDto> GetTaskById(string taskId);
    }
}
