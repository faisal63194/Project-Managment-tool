using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ProjectManagmentTool.DAL;
using ProjectManagmentTool.Models;

namespace ProjectManagmentTool.BLL
{
    public class TaskManager
    {
        private TaskGatway taskGatway;

        public DataTable GetAllPriority()
        {
            taskGatway = new TaskGatway();
            return taskGatway.GetAllPriority();
        }

        public int SaveTask(TaskModel taskModel)
        {
            taskGatway = new TaskGatway();
            return taskGatway.SaveTask(taskModel);
        }
    }
}