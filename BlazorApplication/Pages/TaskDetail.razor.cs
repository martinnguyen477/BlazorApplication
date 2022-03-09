using BlazorApplication.Models;
using BlazorApplication.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorApplication.Pages
{
    public partial class TaskDetail
    {

        [Inject]
         private ITaskClientAPI taskClientAPI { get; set; }


        [Parameter]
        public string TaskId { set; get; }

        public TaskDto TaskDetails; 

        protected async override Task OnInitializedAsync()
        {
            TaskDetails = await taskClientAPI.GetTaskById(TaskId);
        }
    }
}
