using System;
using BlazorApplication.Models.Enum;

namespace BlazorApplication.Models
{
    public class TaskDto
    {
        public Guid TaskId { get; set; }

        public string TaskName { get; set; }

        public Guid? AssigneeId { get; set; }

        public string AssigneeName { set; get; }

        public DateTime CreateDate { get; set; }

        public Priority Priority { get; set; }

        public Status Status { get; set; }
    }
}
