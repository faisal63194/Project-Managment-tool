using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagmentTool.BLL;
using ProjectManagmentTool.Models;

namespace ProjectManagmentTool.Controllers
{
    public class AddTaskController : Controller
    {
        // GET: AddTask
        public ActionResult SaveTask()
        {
            ViewBag.listOfUser = GetUser();
            ViewBag.listOfProject = GetProject();
            ViewBag.listOfPriority = GetAllPriority();
            return View();
        }

        [HttpPost]

        public ActionResult SaveTask(TaskModel taskModel)
        { 
            TaskManager taskManager=new TaskManager();
            int rowCout = taskManager.SaveTask(taskModel);
            if(rowCout>0)
            {
                ViewBag.mgs = "New Task has been saved .";

            }
            else
            {
                ViewBag.error = "Not Saved .";
            }

            ViewBag.listOfUser = GetUser();
            ViewBag.listOfProject = GetProject();
            ViewBag.listOfPriority = GetAllPriority();
            return View();
        }

        public List<UserModel> GetUser()
        {
            AssignPersonManager assignPersonManager = new AssignPersonManager();
            List<UserModel> userList = new List<UserModel>();
            if (assignPersonManager.GetAllPerson().Rows.Count > 0)
            {
                for (int i = 0; i < assignPersonManager.GetAllPerson().Rows.Count; i++)
                {
                    UserModel userModel = new UserModel();
                    userModel.Name = assignPersonManager.GetAllPerson().Rows[i]["Name"].ToString();
                    userModel.UserId = Convert.ToInt32(assignPersonManager.GetAllPerson().Rows[i]["UserId"].ToString());
                    userList.Add(userModel);
                }

            }
            return userList;
        }

        public List<ProjectModel> GetProject()
        {
            AssignPersonManager assignPersonManager = new AssignPersonManager();
            List<ProjectModel> projeectList = new List<ProjectModel>();
            if (assignPersonManager.GetAllProject().Rows.Count > 0)
            {
                for (int i = 0; i <= assignPersonManager.GetAllPerson().Rows.Count; i++)
                {
                    ProjectModel projectModel = new ProjectModel();
                    projectModel.ProjectName = assignPersonManager.GetAllProject().Rows[i]["ProjectName"].ToString();
                    projectModel.ProjectId =
                        Convert.ToInt32(assignPersonManager.GetAllProject().Rows[i]["ProjectId"].ToString());
                    projeectList.Add(projectModel);
                }
            }
            return projeectList;

        }

        public List<PriorityModel> GetAllPriority()
        {
            TaskManager taskManager = new TaskManager();
            List<PriorityModel> priorityList = new List<PriorityModel>();
            if (taskManager.GetAllPriority().Rows.Count > 0)
            {
                for (int i = 0; i < taskManager.GetAllPriority().Rows.Count; i++)
                {
                    PriorityModel priority = new PriorityModel();
                    priority.Priority = taskManager.GetAllPriority().Rows[i]["Priority"].ToString();
                    priority.PriorityId =
                        Convert.ToInt32(taskManager.GetAllPriority().Rows[i]["PriorityId"].ToString());
                    priorityList.Add(priority);
                }
            }
            return priorityList;
        }
    }
}