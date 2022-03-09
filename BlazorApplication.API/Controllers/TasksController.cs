using System;
using System.Linq;
using System.Threading.Tasks;
using BlazorApplication.API.Entities;
using BlazorApplication.API.Repositories;
using BlazorApplication.Models;
using BlazorApplication.Models.Enum;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApplication.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        //[HttpGet]
        //// Mình có thể sử dụng Task<List<TaskEntities>> và trả về danh sách luôn. Nhưng mình recommend nên sử dụng Ok và Bad Request để hiển thị ra lỗi khi có lỗi.
        //public async Task<List<TaskEntities>> GetAllTask()
        //{
        //    return await _taskRepository.GetTaskList();
        //}
        //tasks/getall?name=cuong?fd
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] TaskListSearch taskListSearch)
        {
            var result = await _taskRepository.GetTaskList(taskListSearch);
            var resultDto = result.Select(x => new TaskDto()
            {
                TaskId = x.TaskId,
                Status = x.Status,
                CreateDate = x.CreateDate,
                Priority = x.Priority,
                TaskName = x.TaskName,
                AssigneeName = x.Assignee != null ? x.Assignee.FirstName + " " + x.Assignee.LastName : "N/A"
            }) ;

            return Ok(resultDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskCreateRequest taskCreateRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var taskCreated = await _taskRepository.Create(new TaskEntities() { 
                TaskId = taskCreateRequest.Id,
                TaskName = taskCreateRequest.TaskName,
                Priority = taskCreateRequest.Priority.HasValue ? taskCreateRequest.Priority.Value : Priority.Low,
                Status = Status.Open,
                CreateDate = DateTime.Now
            });
            return Ok(taskCreated);
        }

        [HttpPost("{taskId}")]
        public async Task<IActionResult> UpdateTask(Guid taskId, TaskUpdateRequest taskUpdateRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var taskbyId =await _taskRepository.GetById(taskId);

            if (taskbyId == null) return NotFound($"{taskId} not found");

            taskbyId.TaskName = taskUpdateRequest.Name;
            taskbyId.Priority = taskUpdateRequest.Priority;

            var taskUpdated = await _taskRepository.Update(taskbyId);

            return Ok( new TaskDto()
            {
                TaskName = taskbyId.TaskName,
                Status = taskbyId.Status,
                TaskId = taskbyId.TaskId,
                AssigneeId = taskbyId.AssigneeId,
                Priority = taskbyId.Priority,
                CreateDate = taskbyId.CreateDate
            });
        }
        [HttpDelete]
        [Route("{taskId}")]
        public async Task<IActionResult> DeleteTask([FromRoute] Guid taskId)
        {
            var task = await _taskRepository.GetById(taskId);
            if (task == null) return NotFound($"{taskId} is not found");

            var taskDeleted = await _taskRepository.Delete(task);
            return Ok(new TaskDto()
            {
                TaskName = taskDeleted.TaskName,
                Status = taskDeleted.Status,
                TaskId = taskDeleted.TaskId,
                AssigneeId = taskDeleted.AssigneeId,
                Priority = taskDeleted.Priority,
                CreateDate = taskDeleted.CreateDate
            });
        }

        [HttpGet("{taskId}")]
        public async Task<IActionResult> GetById(Guid taskId)
        {
            var taskById = await _taskRepository.GetById(taskId);
            if (taskById == null)
                return NotFound($"{taskId} is not found");
            return Ok(taskById);
        }
    }
}
