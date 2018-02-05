using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagmentTool.Models
{
    public class AssignPerson
    {
        public int Id { get; set; }
        public string ProjectId { get; set; }
        public string UserId { get; set; }

    }
}