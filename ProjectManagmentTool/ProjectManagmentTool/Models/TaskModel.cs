using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagmentTool.Models
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int PriorityId { get; set; }
    }
}