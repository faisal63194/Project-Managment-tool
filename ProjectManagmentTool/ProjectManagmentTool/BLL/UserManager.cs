using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ProjectManagmentTool.DAL;

namespace ProjectManagmentTool.BLL
{
    public class UserManager
    {
        private UserGateway aUserGateway;

        public DataTable IsExistEmail(string email)
        {
            aUserGateway=new UserGateway();
            return aUserGateway.IsExistEmail(email);
        }

    }
}