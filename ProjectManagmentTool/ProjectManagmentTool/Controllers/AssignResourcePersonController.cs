using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagmentTool.Models;

namespace ProjectManagmentTool.Controllers
{
    public class AssignResourcePersonController : Controller
    {
        // GET: AssignResourcePerson
        public ActionResult AssignResoursePerson(AssignPerson assignPerson)
        {
            return View();
        }
    }
} 