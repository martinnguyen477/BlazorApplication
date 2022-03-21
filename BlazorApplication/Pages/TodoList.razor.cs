using BlazorApplication.Models;
using BlazorApplication.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApplication.Pages
{
    public partial class TodoList
    {
        [Inject] private ITaskClientAPI taskClientAPI { get; set; }

        [Inject] private IUserClientAPI userClientAPI { get; set; }
        
        private TaskListSearch taskListSearch = new TaskListSearch();

        private List<AssigneeDto> AssigneeList = new List<AssigneeDto>();

        private List<TaskDto> tasks;
        protected override async Task OnInitializedAsync()
        {
            tasks = await taskClientAPI.GetTaskList(taskListSearch);
            AssigneeList = await userClientAPI.GetListAssignee();
        }
        private async void SearchForm(EditContext editContext)
        {
            tasks =await taskClientAPI.GetTaskList(taskListSearch);
        }
    }
    //Update
}
