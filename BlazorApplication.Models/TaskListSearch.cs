using BlazorApplication.Models.Enum;
using System;

namespace BlazorApplication.Models
{
    public class TaskListSearch
    {
        public string Name { get; set; }

        public Guid? AssignId { get; set; }

        public Priority? Priority { get; set; }
    }
}
