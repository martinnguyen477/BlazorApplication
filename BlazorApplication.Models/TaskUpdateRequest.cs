using BlazorApplication.Models.Enum;

namespace BlazorApplication.Models
{
    public class TaskUpdateRequest
    {
        public string Name { get; set; }

        public Priority Priority { get; set; }
    }
}
