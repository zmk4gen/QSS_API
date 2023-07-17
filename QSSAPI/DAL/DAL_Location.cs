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
    public class DAL_Location
    {
        public DataTable BindLocation()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindLocation_API";
            cmd.CommandType = CommandType.StoredProcedure;
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindLocationByNumber(string number)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindLocation_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@loc_code", number);
            cmd.Parameters.AddWithValue("@status", "true");
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindLocationByName(string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindLocation_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@loc_Name", name);
            cmd.Parameters.AddWithValue("@status", "false");
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindLocationByCodeANDName(string code,string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindLocation_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@loc_code", code);
            cmd.Parameters.AddWithValue("@loc_Name", name);
            cmd.Parameters.AddWithValue("@status", "false");
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public int Insert_Location(BOL_Location bol_Location)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "InsertLocation";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@loc_Code", bol_Location.loc_Code);
            cmd.Parameters.AddWithValue("@loc_Name", bol_Location.loc_Name);
            cmd.Parameters.AddWithValue("@loc_BranchID", bol_Location.loc_BranchID);
            cmd.Parameters.AddWithValue("@loc_createby", bol_Location.loc_createby);
            cmd.Parameters.AddWithValue("@loc_createdate", bol_Location.loc_createdate);
            cmd.Parameters.AddWithValue("@loc_updateby", bol_Location.loc_updateby);
            cmd.Parameters.AddWithValue("@loc_lastupdate", bol_Location.loc_LastUpdate);
            cmd.Parameters.AddWithValue("@loc_inactive", bol_Location.loc_inactive);
       
            return SqlConjunction.GetSQLTransVoid(cmd);
        }
    }
}