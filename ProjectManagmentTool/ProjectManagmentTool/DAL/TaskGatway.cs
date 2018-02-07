using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ProjectManagmentTool.Models;

namespace ProjectManagmentTool.DAL
{
    public class TaskGatway
    {
        private DataTable dt;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        ConnectionClass oConnectionClass=new ConnectionClass();

        public DataTable GetAllPriority()
        {
            dt = new DataTable();
            string sql = "Select * from Priority_tb";
            da = new SqlDataAdapter(sql, oConnectionClass.GetConnection());
            da.Fill(dt);
            oConnectionClass.GetColse();
            return dt;
        }

        public int SaveTask(TaskModel taskModel)
        {
            int rowCount = 0;
            string sql =
                "Insert into Task_tb(ProjectId,UserId,Description,DueDate,Priority) Values(@ProjectId,@UserId,@Description,@DueDate,@Priority)";

            cmd=new SqlCommand(sql,oConnectionClass.GetConnection());
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("ProjectId",taskModel.ProjectId);
            cmd.Parameters.AddWithValue("UserId", taskModel.UserId);
            cmd.Parameters.AddWithValue("Description", taskModel.Description);
            cmd.Parameters.AddWithValue("DueDate", taskModel.DueDate);
            cmd.Parameters.AddWithValue("Priority", taskModel.PriorityId);
            rowCount = cmd.ExecuteNonQuery();
            return rowCount;
        }
    }
}