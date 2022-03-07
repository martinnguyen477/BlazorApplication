using BlazorApplication.API.Entities;
using System;
using System.Threading.Tasks;
using Task = BlazorApplication.API.Entities.TaskEntities;

namespace BlazorApplication.API.Repositories
{
    public interface ITaskRepository
    {
        Task<PagedList<TaskEntities>> GetTaskList(TaskListSearch taskListSearch);

        Task<PagedList<TaskEntities>> GetTaskListByUserId(Guid userId, TaskListSearch taskListSearch);

        Task<Task> Create(TaskEntities task);

        Task<Task> Update(TaskEntities task);

        Task<Task> Delete(TaskEntities task);

        Task<Task> GetById(TaskEntities id);
    }
}
