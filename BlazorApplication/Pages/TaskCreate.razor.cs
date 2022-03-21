using BlazorApplication.Models;
using BlazorApplication.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApplication.Pages
{
    public partial class TaskCreate
    {
        [Inject] private ITaskClientAPI taskClientAPI { get; set; }

        [Inject] private NavigationManager navigationManager { get; set; }

        private TaskCreateRequest Task = new TaskCreateRequest();

        private async void SubmitCreateForm(EditContext editContext)
        {
             var result = await taskClientAPI.CreateTask(Task);
            if(result)
            {
                navigationManager.NavigateTo("/TaskList");
            }     
        }

        //CUong
    }
    
}
