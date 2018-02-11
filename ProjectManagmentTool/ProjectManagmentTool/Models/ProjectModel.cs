using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagmentTool.Models
{
    public class ProjectModel
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string CodeName { get; set; }
        public string Description { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public int Duration { get; set; }
        public HttpPostedFileBase UploadFilePath { get; set; }
        public string UFile { get; set; }
        public string Status { get; set; }
    }
}