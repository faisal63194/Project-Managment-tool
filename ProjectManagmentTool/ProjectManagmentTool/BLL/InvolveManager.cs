using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ProjectManagmentTool.DAL;

namespace ProjectManagmentTool.BLL
{
    public class InvolveManager
    {
        private InvolveGatway involveGatway;

        public DataTable ShowAllInvolvePerson()
        {
            involveGatway=new InvolveGatway();
            return involveGatway.ShowAllInvolvePerson();
        }
    }
}