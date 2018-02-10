using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ProjectManagmentTool.DAL;

namespace ProjectManagmentTool.BLL
{
    public class ShowProjectManager
    {
        private ShowProjectGatway showProjectGatway;

        public DataTable GetAllProjectDeatils(int projectId)
        {
            showProjectGatway=new ShowProjectGatway();
            return showProjectGatway.GetAllProjectDeatils(projectId);
        }

        public DataTable GetAllTaskInfo()
        {
            showProjectGatway = new ShowProjectGatway();
            return showProjectGatway.GetAllTaskInfo();
        }

    }
}