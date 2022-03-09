using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApplication.API.DataContext;
using BlazorApplication.API.Entities;
using BlazorApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApplication.API.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TodoDbContext _context;

        public TaskRepository(TodoDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskEntities>> GetTaskList(TaskListSearch taskListSearch)
        {
            var result = _context.Tasks
                .Include(x => x.Assignee)
                .AsQueryable();
            if(!string.IsNullOrEmpty(taskListSearch.Name))
            {
                result = result.Where(x => x.TaskName.Contains(taskListSearch.Name));
            }    
            if(taskListSearch.AssignId.HasValue)
            {
                result = result.Where(x => x.AssigneeId == taskListSearch.AssignId.Value);
            }
            if (taskListSearch.Priority.HasValue)
            {
                result = result.Where(x => x.Priority == taskListSearch.Priority.Value);
            }

            return await result.OrderByDescending(x => x.CreateDate).ToListAsync();
        }

        public async Task<TaskEntities> Create(TaskEntities task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<TaskEntities> Update(TaskEntities task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<TaskEntities> Delete(TaskEntities task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<TaskEntities> GetById(Guid id)
        {
            return await _context.Tasks.FindAsync(id);
        }
    }
}
