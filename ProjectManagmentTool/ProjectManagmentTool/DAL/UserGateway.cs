using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ProjectManagmentTool.Models;

namespace ProjectManagmentTool.DAL
{
    public class UserGateway
    {
        private DataTable dt;
        private SqlDataAdapter da;
        private SqlCommand cmd;
        ConnectionClass oConnectionClass=new ConnectionClass();

        public DataTable IsExistEmail(string email)
        {
            dt=new DataTable();
            string sql = "Select * from UserModels where Email='"+email+"'";
            try
            {

                da=new SqlDataAdapter(sql,oConnectionClass.GetConnection());
                da.Fill(dt);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw;
            }
            finally
            {
                oConnectionClass.GetColse();
            }
            return dt;
        }
    }
}