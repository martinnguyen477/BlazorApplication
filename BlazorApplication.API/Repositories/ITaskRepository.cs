using BlazorApplication.API.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApplication.API.Repositories
{
    public interface ITaskRepository
    {
        Task<List<TaskEntities>> GetTaskList();

        Task<TaskEntities> Create(TaskEntities task);

        Task<TaskEntities> Update(TaskEntities task);

        Task<TaskEntities> Delete(TaskEntities task);

        Task<TaskEntities> GetById(Guid id);
    }
}
