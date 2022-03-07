using System;
using System.Linq;
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

        public async Task<PagedList<Entities.TaskEntities>> GetTaskList(TaskListSearch taskListSearch)
        {
            var query = _context.Tasks
                .Include(x => x.Assignee).AsQueryable();

            if (!string.IsNullOrEmpty(taskListSearch.Name))
                query = query.Where(x => x.TaskName.Contains(taskListSearch.Name));

            if (taskListSearch.AssigneeId.HasValue)
                query = query.Where(x => x.AssigneeId == taskListSearch.AssigneeId.Value);

            if (taskListSearch.Priority.HasValue)
                query = query.Where(x => x.Priority == taskListSearch.Priority.Value);

            var count = await query.CountAsync();

            var data = await query.OrderByDescending(x => x.CreateDate)
                .Skip((taskListSearch.PageNumber - 1) * taskListSearch.PageSize)
                .Take(taskListSearch.PageSize)
                .ToListAsync();
            return new PagedList<TaskEntities>(data, count, taskListSearch.PageNumber, taskListSearch.PageSize);

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

        public async Task<PagedList<TaskEntities>> GetTaskListByUserId(Guid userId, TaskListSearch taskListSearch)
        {
            var query = _context.Tasks
                    .Where(x => x.AssigneeId == userId)
                 .Include(x => x.Assignee).AsQueryable();

            if (!string.IsNullOrEmpty(taskListSearch.Name))
                query = query.Where(x => x.TaskName.Contains(taskListSearch.Name));

            if (taskListSearch.AssigneeId.HasValue)
                query = query.Where(x => x.AssigneeId == taskListSearch.AssigneeId.Value);

            if (taskListSearch.Priority.HasValue)
                query = query.Where(x => x.Priority == taskListSearch.Priority.Value);

            var count = await query.CountAsync();

            var data = await query.OrderByDescending(x => x.CreateDate)
                .Skip((taskListSearch.PageNumber - 1) * taskListSearch.PageSize)
                .Take(taskListSearch.PageSize)
                .ToListAsync();
            return new PagedList<TaskEntities>(data, count, taskListSearch.PageNumber, taskListSearch.PageSize);
        }
    }
}
