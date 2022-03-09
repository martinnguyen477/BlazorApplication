using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApplication.API.DataContext;
using BlazorApplication.API.Entities;
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

        public async Task<List<TaskEntities>> GetTaskList()
        { 
            var result = await _context.Tasks
                .Include(x => x.Assignee)
                .ToListAsync();
            return result;
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
