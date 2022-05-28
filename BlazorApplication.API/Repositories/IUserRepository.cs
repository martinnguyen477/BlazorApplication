using BlazorApplication.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApplication.API.Repositories
{
    public interface IUserRepository
    {
        Task<List<UserEntities>> GetUserList();
        //test2
        //test
        //test3
    }
}
