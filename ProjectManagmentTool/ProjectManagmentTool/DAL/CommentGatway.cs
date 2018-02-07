using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ProjectManagmentTool.Models;

namespace ProjectManagmentTool.DAL
{
    public class CommentGatway
    {
        private DataTable dt;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        ConnectionClass oConnectionClass=new ConnectionClass();

        public DataTable GetAllTask()
        {
            dt = new DataTable();
            string sql = "Select TaskId,Description from Task_tb";
            da = new SqlDataAdapter(sql, oConnectionClass.GetConnection());
            da.Fill(dt);
            oConnectionClass.GetColse();
            return dt;
        }

        public int SaveComment(CommentModel comment)
        {
            int rowCount = 0;
            string sql = "Insert into Comment_tb(ProjectId,TaskId,Comment)Values(@ProjectId,@TaskId,@Comment)";
            cmd=new SqlCommand(sql,oConnectionClass.GetConnection());
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("ProjectId", comment.ProjectId);
            cmd.Parameters.AddWithValue("TaskId", comment.TaskId);
            cmd.Parameters.AddWithValue("Comment", comment.Comment);
            rowCount = cmd.ExecuteNonQuery();
            return rowCount;
        }
    }
}