using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ProjectManagmentTool.BLL;
using ProjectManagmentTool.DAL;
using ProjectManagmentTool.Models;

namespace ProjectManagmentTool.Controllers
{
    public class AddProjectController : Controller
    {
        // GET: AddProject
        public ActionResult AddProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProject(ProjectModel aProjectModel)
        {
            AddProjectManager addProjectManager = new AddProjectManager();
         
            //var InputFileName = Path.GetFileName(File);
            //var ServerSavePath = Path.Combine(Server.MapPath("~/Files/") + InputFileName);
            int rowCount = addProjectManager.SaveProject(aProjectModel);
            if (rowCount > 0)
            {
                ViewBag.mgs = "Add project has been saved successfully.";
            }
            else
            {
                ViewBag.mgs = "Not saved";
            }
            return View();
        }


        
    }
}