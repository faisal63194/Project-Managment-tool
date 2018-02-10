using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ProjectManagmentTool.Models;

namespace ProjectManagmentTool.DAL
{
    public class ShowProjectGatway
    {
        private DataTable dt;
        private SqlDataAdapter da;
        private SqlCommand cmd;

        ConnectionClass oConnectionClass=new ConnectionClass();


        public DataTable GetAllProjectDeatils(int projectId)
        {
            dt=new DataTable();
            string sql = "Select * from AddProject_tb where ProjectId=@ProjectId";
            cmd=new SqlCommand(sql,oConnectionClass.GetConnection());
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("ProjectId", projectId);
            da=new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public DataTable GetAllTaskInfo()
        {
            dt=new DataTable();
            string sql =
                "Select a.Description,u.Name,u.Designation,p.Priority,t.DueDate from Task_tb As t inner join AddProject_tb as a on a.ProjectId=t.ProjectId inner join UserModels as u on u.UserId=t.UserId inner join Priority_tb as p on p.PriorityId=t.Priority";
            da = new SqlDataAdapter(sql,oConnectionClass.GetConnection());
            da.Fill(dt);
            return dt;
        }

        
    }
}