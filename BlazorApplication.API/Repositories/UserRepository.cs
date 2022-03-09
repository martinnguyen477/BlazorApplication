using BlazorApplication.API.DataContext;
using BlazorApplication.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApplication.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TodoDbContext _context;

        public UserRepository(TodoDbContext context)
        {
            _context = context;
        }
        public async Task<List<UserEntities>> GetUserList()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
