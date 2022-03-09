using BlazorApplication.Models.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApplication.API.Entities
{
    public class TaskEntities
    {
        [Key]
        public Guid TaskId { get; set; }

        [MaxLength(250)]
        [Required]
        public string TaskName { get; set; }

        /// <summary>
        /// Guid? có thể Null được.
        /// </summary>
        public Guid? AssigneeId { get; set; }

        [ForeignKey("AssigneeId")]
        public UserEntities Assignee { get; set; }

        public DateTime CreateDate { get; set; }

        public Priority Priority { get; set; }

        public Status Status { get; set; }
    }
}
