using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace ProjectManagmentTool.Models
{
    public class InvolveModel
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string CodeName { get; set; }

        public string Status { get; set; }
        public int NoOfMember { get; set; }
        public int NoOfTask { get; set; }
    }
}