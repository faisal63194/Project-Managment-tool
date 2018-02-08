using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagmentTool.BLL;
using ProjectManagmentTool.Models;

namespace ProjectManagmentTool.Controllers
{
    public class InvolvePersonController : Controller
    {
        // GET: InvolvePerson
        public ActionResult Index()
        {
            InvolveManager involveManager=new InvolveManager();
            List<InvolveModel> involveList=new List<InvolveModel>();
           
            var path = involveManager.ShowAllInvolvePerson();
            if(involveManager.ShowAllInvolvePerson().Rows.Count>0)
            {
                for (int i=0; i <path.Rows.Count; i++)
                {
                    InvolveModel involve = new InvolveModel();
                    involve.ProjectName = path.Rows[i]["ProjectName"].ToString();
                    involve.CodeName = path.Rows[i]["CodeName"].ToString();
                    involve.Status = path.Rows[i]["Status"].ToString();
                    involve.NoOfMember = Convert.ToInt32(path.Rows[i]["Noofmember"].ToString());
                    involve.NoOfTask = Convert.ToInt32(path.Rows[i]["NoofTask"].ToString());
                    involveList.Add(involve);
                }
                ViewBag.listOfInvolvePerson = involveList;
            }

            return View();
        }
    }
}