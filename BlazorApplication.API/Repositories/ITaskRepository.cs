using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApplication.API.Entities;
using BlazorApplication.Models;

namespace BlazorApplication.API.Repositories
{
    public interface ITaskRepository
    {
        Task<List<TaskEntities>> GetTaskList(TaskListSearch taskListSearch);

        Task<TaskEntities> Create(TaskEntities task);

        Task<TaskEntities> Update(TaskEntities task);

        Task<TaskEntities> Delete(TaskEntities task);

        Task<TaskEntities> GetById(Guid id);
    }
}
