using BlazorApplication.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApplication.Services
{
    public class TaskClientAPI : ITaskClientAPI
    {
        private HttpClient _httpClient;

        public TaskClientAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TaskDto> GetTaskById(string taskId)
        {
            var result = _httpClient.GetFromJsonAsync<TaskDto>($"/api/Tasks/GetById/{taskId}");
            return await result;
        }

        public async Task<List<TaskDto>> GetTaskList(TaskListSearch taskListSearch)
        {
            var url = $"/api/Tasks/GetAll?name={taskListSearch.Name}&assignId={taskListSearch.AssignId}&priority={taskListSearch.Priority}";
            var result = _httpClient.GetFromJsonAsync<List<TaskDto>>(url);
            return await result;
        }
    }
}
