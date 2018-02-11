using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagmentTool.BLL;
using ProjectManagmentTool.Models;

namespace ProjectManagmentTool.Controllers
{
    public class ViewCommentController : Controller
    {
        // GET: ViewComment
        public ActionResult Index(int ProjectId)
        {
            CommentManager commentManager = new CommentManager();
            List<CommentModel> commentList = new List<CommentModel>();
            var path = commentManager.GetCommetInfo(ProjectId).Rows;
            ViewBag.result = path.Count;
            if (path.Count > 0)
            {
                for (int i = 0; i < path.Count; i++)
                {
                    CommentModel viewComment = new CommentModel();
                    viewComment.Comment = path[i]["Comment"].ToString();
                    viewComment.DateTime = path[i]["DateTime"].ToString();
                    commentList.Add(viewComment);
                }
                ViewBag.listOfComment = commentList;
            }
            return View();
        }

        public JsonResult GetProjectInfo(int ProjectId)
        {
            CommentManager commentManager = new CommentManager();
            List<ViewCommentModel> commentList = new List<ViewCommentModel>();
            var path = commentManager.GetProjectInfo(ProjectId).Rows;
            if (path.Count > 0)
            {
                for (int i = 0; i < path.Count; i++)
                {
                    ViewCommentModel viewComment = new ViewCommentModel();
                    viewComment.ProjectName = path[i]["ProjectName"].ToString();
                    viewComment.Description = path[i]["Description"].ToString();
                    commentList.Add(viewComment);
                }
               
            }
            return Json(commentList);
        }

    }
}