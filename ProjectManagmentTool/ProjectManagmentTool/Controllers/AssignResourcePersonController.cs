using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagmentTool.BLL;
using ProjectManagmentTool.Models;

namespace ProjectManagmentTool.Controllers
{
    public class AssignResourcePersonController : Controller
    {
        // GET: AssignResourcePerson
        public ActionResult AssignResoursePerson()
        {
            ViewBag.listOfShowAssignPerson = ShowAssignPerson();
            ViewBag.listofUsesr = GetUser();
            ViewBag.listOfProject = GetProject();

            return View();
        }

        [HttpPost]
        public ActionResult AssignResoursePerson(int selectProject, int selectUser)
        {
            AssignPerson assignPerson = new AssignPerson();
            assignPerson.ProjectId = selectProject;
            assignPerson.UserId = selectUser;

            AssignPersonManager assignPersonManager = new AssignPersonManager();
            try
            {
                int rowCount = assignPersonManager.SaveAssignPerson(assignPerson);
                if (rowCount > 0)
                {
                    ViewBag.mgs = "Person Assign has been successfully .";
                }
            }
            catch (Exception e)
            {
                ViewBag.mgs = e.Message;
            }
            ViewBag.listofUsesr = GetUser();
            ViewBag.listOfProject = GetProject();
            ViewBag.listOfShowAssignPerson = ShowAssignPerson();






            return View();
        }

        public List<AssignShowPerson> ShowAssignPerson()
        {
            AssignPersonManager assignPersonManager = new AssignPersonManager();
            List<AssignShowPerson> showPersonsList = new List<AssignShowPerson>();
            if (assignPersonManager.GetAllAssignInfo().Rows.Count > 0)
            {
                for (int i = 0; i < assignPersonManager.GetAllAssignInfo().Rows.Count; i++)
                {
                    AssignShowPerson assignShowPerson = new AssignShowPerson();
                    assignShowPerson.ProjectName = assignPersonManager.GetAllAssignInfo().Rows[i]["ProjectName"].ToString();
                    assignShowPerson.Name =
                        assignPersonManager.GetAllAssignInfo().Rows[i]["Name"].ToString();
                    assignShowPerson.Designation =
                        assignPersonManager.GetAllAssignInfo().Rows[i]["Designation"].ToString();
                    showPersonsList.Add(assignShowPerson);
                }
            }
            return showPersonsList;
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
                for (int i = 0; i < assignPersonManager.GetAllPerson().Rows.Count; i++)
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
    }
}