using BlazorApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApplication.Services
{
    public interface IUserClientAPI
    {
        Task<List<AssigneeDto>> GetListAssignee(); 
    }
}
