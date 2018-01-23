using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjectManagmentTool.Models
{
    public class ConnectionClass
    {
        private SqlConnection con;
        public SqlConnection GetConnection()
        {
            string conectringstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
           con=new SqlConnection("Data Source=DESKTOP-P55O1AE;Initial Catalog=ProjectManagment;Integrated Security=True");
            if(con.State==ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }
            else
            {
                con.Open();
            }
            return con;
        }

        public void GetColse()
        {
            if(con!=null)
            {
                con.Close();
            }
        }
    }
}