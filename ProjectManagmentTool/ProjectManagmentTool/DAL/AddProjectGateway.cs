using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ProjectManagmentTool.Models;

namespace ProjectManagmentTool.DAL
{
    public class AddProjectGateway
    {
        private DataTable dt;
        private SqlCommand cmd;
        ConnectionClass oConnectionClass=new ConnectionClass();

        public int SaveProject(ProjectModel aProjectModel)
        {
            int rowCount = 0;
           
            string sql =
                "Insert into AddProject_tb(ProjectName,CodeName,Description,StartDateTime,EndDateTime,Duration,UploadFilePath,Status)Values(@ProjectName,@CodeName,@Description,@StartDateTime,@EndDateTime,@Duration,@UploadFilePath,@Status)";
            try
            {
                cmd = new SqlCommand(sql, oConnectionClass.GetConnection());
                cmd.Parameters.AddWithValue("ProjectName", aProjectModel.ProjectName);
                cmd.Parameters.AddWithValue("CodeName", aProjectModel.CodeName);
                cmd.Parameters.AddWithValue("Description", aProjectModel.Description);
                cmd.Parameters.AddWithValue("StartDateTime", aProjectModel.StartDateTime);
                cmd.Parameters.AddWithValue("EndDateTime", aProjectModel.EndDateTime);
                cmd.Parameters.AddWithValue("Duration", aProjectModel.Duration);
                cmd.Parameters.AddWithValue("UploadFilePath", aProjectModel.UploadFilePath);
                cmd.Parameters.AddWithValue("Status", aProjectModel.Status);
                rowCount = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
            finally
            {
                oConnectionClass.GetColse();
            }
            return rowCount;
        }
    }
}