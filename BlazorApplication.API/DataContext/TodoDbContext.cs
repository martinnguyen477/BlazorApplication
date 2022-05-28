using BlazorApplication.API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlazorApplication.API.DataContext
{
    public class TodoDbContext : IdentityDbContext<UserEntities, RoleEntities, Guid>
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
        }

        public DbSet<TaskEntities> Tasks { get; set; }
    }
}