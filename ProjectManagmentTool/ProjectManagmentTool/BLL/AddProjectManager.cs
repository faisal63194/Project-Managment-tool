using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManagmentTool.DAL;
using ProjectManagmentTool.Models;

namespace ProjectManagmentTool.BLL
{
    public class AddProjectManager
    {
        private AddProjectGateway addProjectGateway;

        public int SaveProject(ProjectModel aProjectModel)
        {
            addProjectGateway=new AddProjectGateway();
            int rowCount = addProjectGateway.SaveProject(aProjectModel);
            return rowCount;
        }
    }
}