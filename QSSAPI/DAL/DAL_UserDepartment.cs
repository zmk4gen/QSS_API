using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using QSSAPI.BOL;
using DAL;

namespace QSSAPI.DAL
{
    public class DAL_UserDepartment
    {
        public DataTable BindUserDepartment()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindUserDepartment_API";
            cmd.CommandType = CommandType.StoredProcedure;
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindUserDepartmentByNumber(string number)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindUserDepartment_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ud_code", number);

            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindUserDepartmentByName(string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindUserDepartment_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ud_name", name);
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public int Insert_UserDepartment(BOL_UserDepartment bol_UserDepartment)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert_UserDepartment";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ud_ID", bol_UserDepartment.ud_ID);
            cmd.Parameters.AddWithValue("@ud_Code", bol_UserDepartment.ud_Code);
            cmd.Parameters.AddWithValue("@ud_Name", bol_UserDepartment.ud_Name);
            cmd.Parameters.AddWithValue("@ud_inactive", bol_UserDepartment.ud_inactive);
            cmd.Parameters.AddWithValue("@ud_lastupdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@ud_updateby", bol_UserDepartment.ud_updateby);
            cmd.Parameters.AddWithValue("@ud_createdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@ud_createby", bol_UserDepartment.ud_createby);
            
            return SqlConjunction.GetSQLTransVoid(cmd);
        }
    }
}