using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ProjectManagmentTool.DAL;
using ProjectManagmentTool.Models;

namespace ProjectManagmentTool.BLL
{
    public class AssignPersonManager
    {
        private AssignPersonGatway assignPersonGatway;

        public DataTable GetAllPerson()
        {
            assignPersonGatway=new AssignPersonGatway();
            return assignPersonGatway.GetAllPerson();
        }

        public DataTable GetAllProject()
        {
            assignPersonGatway = new AssignPersonGatway();
            return assignPersonGatway.GetAllProject();
        }
        public int SaveAssignPerson(AssignPerson assignPerson)
        {
            assignPersonGatway = new AssignPersonGatway();
            if(assignPersonGatway.IsExistUserName(assignPerson.ProjectId,assignPerson.UserId).Rows.Count>0)
            {
                return 0;
            }
            return assignPersonGatway.SaveAssignPerson(assignPerson);
        }

        public DataTable GetAllAssignInfo()
        {
            assignPersonGatway = new AssignPersonGatway();
            return assignPersonGatway.GetAllAssignInfo();
        }

        public DataTable IsExistUserName(int projectId, int userId)
        {
            assignPersonGatway = new AssignPersonGatway();
            return assignPersonGatway.IsExistUserName(projectId, userId);
        }
    }
}