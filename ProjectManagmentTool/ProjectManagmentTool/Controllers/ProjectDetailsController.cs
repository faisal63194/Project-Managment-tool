using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagmentTool.BLL;
using ProjectManagmentTool.Models;

namespace ProjectManagmentTool.Controllers
{
    public class ProjectDetailsController : Controller
    {
        // GET: ProjectDetails
        public ActionResult ShowProjectDetails(int ProjectId)
        {
            ShowProjectManager showProjectManager = new ShowProjectManager();
           

            List<ShowTaskModel>showTaskList=new List<ShowTaskModel>();
            var path1 = showProjectManager.GetAllTaskInfo().Rows;
            ViewBag.result = path1.Count;
            if(path1.Count>0)
            {
                for (int i = 0; i < path1.Count; i++)
                {
                    ShowTaskModel showTask=new ShowTaskModel();
                    showTask.ProjectId = (int) path1[i]["ProjectId"];
                    showTask.Description = path1[i]["Description"].ToString();
                    showTask.Designation = path1[i]["Designation"].ToString();
                    showTask.Name = path1[i]["Name"].ToString();
                    showTask.Priority = path1[i]["Priority"].ToString();
                    showTask.DueDate = Convert.ToDateTime(path1[i]["DueDate"].ToString());
                    showTaskList.Add(showTask);
                }
                ViewBag.allTaskList = showTaskList;
            }
            ViewBag.listOfUser = GetUser();
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
                    userModel.Designation = assignPersonManager.GetAllPerson().Rows[i]["Designation"].ToString();
                    userList.Add(userModel);
                }

            }
            return userList;
        }
        public JsonResult GetInfo(int ProjectId)
        {
            ShowProjectManager showProjectManager = new ShowProjectManager();
            List<ProjectModel> showList = new List<ProjectModel>();
            var path = showProjectManager.GetAllProjectDeatils(ProjectId).Rows;
            if (path.Count > 0)
            {
                for (int i = 0; i < path.Count; i++)
                {
                    ProjectModel projectModel = new ProjectModel();
                    projectModel.ProjectName = path[i]["ProjectName"].ToString();
                    projectModel.CodeName = path[i]["CodeName"].ToString();
                    projectModel.Description = path[i]["Description"].ToString();
                    projectModel.Duration = (int)path[i]["Duration"];
                    projectModel.StartDateTime = path[i]["StartDateTime"].ToString();
                    projectModel.EndDateTime = path[i]["EndDateTime"].ToString();
                    projectModel.Status = path[i]["Status"].ToString();
                    projectModel.UFile = path[i]["UploadFilePath"].ToString();
                    showList.Add(projectModel);

                }
                

            }
            return Json(showList);
        }
        
    }
}