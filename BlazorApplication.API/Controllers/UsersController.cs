using System.Linq;
using System.Threading.Tasks;
using BlazorApplication.API.Repositories;
using BlazorApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApplication.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.GetUserList();
            var assigneeList = users.Select(x => new AssigneeDto()
            {
                Id = x.Id,
                FullName = x.FirstName + " " + x.LastName
            });
            return Ok(assigneeList);
        }
    }
}
