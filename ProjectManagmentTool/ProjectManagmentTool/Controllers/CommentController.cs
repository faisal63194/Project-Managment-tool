using ProjectManagmentTool.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagmentTool.Models;

namespace ProjectManagmentTool.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        public ActionResult SaveComment()
        {
            ViewBag.listOfProject = GetProject();
            //ViewBag.listOfTask = GetAllTask();
            return View();
        }
        [HttpPost]
        public ActionResult SaveComment(CommentModel commentModel)
        {
            CommentManager commentManager=new CommentManager();
            int rowCount = commentManager.SaveComment(commentModel);
            if(rowCount>0)
            {
                ViewBag.mgs = "Comment has been Saved successfully .";
            }
            else
            {
                ViewBag.error = "Not Saved .";
            }
            ViewBag.listOfProject = GetProject();
            //ViewBag.listOfTask = GetAllTask();
            return View();
        }


        public List<ProjectModel> GetProject()
        {
            AssignPersonManager assignPersonManager = new AssignPersonManager();
            List<ProjectModel> projeectList = new List<ProjectModel>();
            if (assignPersonManager.GetAllProject().Rows.Count > 0)
            {
                for (int i = 0; i < assignPersonManager.GetAllProject().Rows.Count; i++)
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

        public JsonResult GetAllTask(int ProjectId)
        {
            CommentManager commentManager=new CommentManager();
            List<TaskModel> taskList = new List<TaskModel>();
            if (commentManager.GetAllTask(ProjectId).Rows.Count > 0)
            {
                for (int i = 0; i < commentManager.GetAllTask(ProjectId).Rows.Count; i++)
                {
                    TaskModel taskModel = new TaskModel();
                    taskModel.Description = commentManager.GetAllTask(ProjectId).Rows[i]["Description"].ToString();
                    taskModel.TaskId =
                        Convert.ToInt32(commentManager.GetAllTask(ProjectId).Rows[i]["TaskId"].ToString());
                    taskList.Add(taskModel);
                }
            }
            return Json(taskList) ;
        }
    }
}