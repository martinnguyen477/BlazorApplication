using System;
using System.Linq;
using System.Threading.Tasks;
using BlazorApplication.API.DataContext;
using BlazorApplication.API.Entities;
using BlazorApplication.Models.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace BlazorApplication.API.Data
{
    public class TodoListContextSeed
    {
        private readonly IPasswordHasher<UserEntities> _passwordHasher = new PasswordHasher<UserEntities>();

        public async Task SeedAsync(TodoDbContext context, ILogger<TodoListContextSeed> logger)
        {
            if (!context.Users.Any())
            {
                var user = new UserEntities()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Mr",
                    LastName = "A",
                    Email = "admin1@gmail.com",
                    NormalizedEmail = "ADMIN1@GMAIL.COM",
                    PhoneNumber = "032132131",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                user.PasswordHash = _passwordHasher.HashPassword(user, "Admin@123$");
                context.Users.Add(user);
            }

            if (!context.Tasks.Any())
            {
                context.Tasks.Add(new Entities.TaskEntities()
                {
                    TaskId = Guid.NewGuid(),
                    TaskName = "Same tasks 1",
                    CreateDate = DateTime.Now,
                    Priority = Priority.High,
                    Status = Status.Open
                });
            }

            await context.SaveChangesAsync();
        }
    }
}
