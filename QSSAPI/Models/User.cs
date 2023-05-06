using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QSSAPI.Models
{
    public class User
    {
        public static bool Login(string username, string password)
        {
            DataTable dt = new DataTable();
            dt =  DAL.SqlConjunction.GetSQLDataTable(new SqlCommand("select u_userName,u_password from User_Info where u_userName='" + username + "' and u_password='" + password + "'"));

            if (dt.Rows.Count > 0) { return true; }
            else { return false; }
        }
    }
}
