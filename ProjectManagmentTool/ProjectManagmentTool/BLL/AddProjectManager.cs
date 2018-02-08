using System;
using System.Collections.Generic;
using System.Data;
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

        public DataTable IsExistProject(string ProjectName)
        {
            addProjectGateway = new AddProjectGateway();
            return addProjectGateway.IsExistProject(ProjectName);
        }
    }
}