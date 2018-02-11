using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagmentTool.Models
{
    public class ShowTaskModel
    {
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Priority { get; set; }
        public DateTime DueDate { get; set; }
    }
}