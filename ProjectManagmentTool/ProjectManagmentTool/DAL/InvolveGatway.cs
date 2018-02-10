using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ProjectManagmentTool.Models;

namespace ProjectManagmentTool.DAL
{
    public class InvolveGatway
    {
        private DataTable dt;
        private SqlDataAdapter da;
        ConnectionClass oConnectionClass=new ConnectionClass();

        public DataTable ShowAllInvolvePerson()
        {
            dt=new DataTable();
            string sql =
                "select noofmember.ProjectId,ProjectName,CodeName,Status,NoofTask,Noofmember from TaskAndAddProject JOIN noofmember on noofmember.ProjectId=TaskAndAddProject.ProjectId";
            da=new SqlDataAdapter(sql,oConnectionClass.GetConnection());
            da.Fill(dt);
            oConnectionClass.GetColse();
            return dt;
        }
    }
}