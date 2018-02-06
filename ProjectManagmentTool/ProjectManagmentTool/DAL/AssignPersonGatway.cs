using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ProjectManagmentTool.Models;

namespace ProjectManagmentTool.DAL
{
    public class AssignPersonGatway
    {
        private DataTable dt;
        private SqlCommand cmd;
        private SqlDataAdapter da;
       
        ConnectionClass oConnectionClass=new ConnectionClass();

        public DataTable GetAllPerson()
        {
            dt=new DataTable();
            string sql = "Select * from UserModels";
            try
            {
                da = new SqlDataAdapter(sql, oConnectionClass.GetConnection());
                da.Fill(dt);
            }
            catch (Exception e)
            {

            }
            finally
            {
                oConnectionClass.GetColse();
            }
            return dt;
        }

        public DataTable GetAllProject()
        {
            dt = new DataTable();
            string sql = "Select * from AddProject_tb";
            try
            {
                da = new SqlDataAdapter(sql, oConnectionClass.GetConnection());
                da.Fill(dt);
            }
            catch (Exception e)
            {

            }
            finally
            {
                oConnectionClass.GetColse();
            }
            return dt;
        }

        public int SaveAssignPerson(AssignPerson assignPerson)
        {
            int rowCount = 0;
            string sql = "Insert into AssignPerson_tb (ProjectId,UserId) Values(@ProjectId,@UserId)";
            cmd = new SqlCommand(sql, oConnectionClass.GetConnection());
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("ProjectId", assignPerson.ProjectId);
            cmd.Parameters.AddWithValue("UserId", assignPerson.UserId);
            rowCount = cmd.ExecuteNonQuery();
            oConnectionClass.GetColse();
            return rowCount;
        }

        public DataTable GetAllAssignInfo()
        {
            dt = new DataTable();
            string sql = "Select ad.ProjectName,u.Name,u.Designation from UserModels as u inner join  AssignPerson_tb as a on u.UserId=a.UserId inner join AddProject_tb as ad on a.ProjectId=ad.ProjectId";
            try
            {
                da = new SqlDataAdapter(sql, oConnectionClass.GetConnection());
                da.Fill(dt);
            }
            catch (Exception e)
            {

            }
            finally
            {
                oConnectionClass.GetColse();
            }
            return dt;
        }
    }
} 