using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagmentTool.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public int ProjectId { get; set; }
        public int TaskId { get; set; }
        public string Comment { get; set; }
    }
}