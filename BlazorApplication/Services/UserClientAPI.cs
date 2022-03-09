using BlazorApplication.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApplication.Services
{
    public class UserClientAPI : IUserClientAPI
    {
        private HttpClient _httpClient;

        public UserClientAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<List<AssigneeDto>> GetListAssignee()
        {
            var result = _httpClient.GetFromJsonAsync<List<AssigneeDto>>("/api/Users/GetAll");
            return result;
        }
    }
}
