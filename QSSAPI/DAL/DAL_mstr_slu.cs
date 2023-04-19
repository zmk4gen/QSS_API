using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using QSSAPI.BOL;
using DAL;
using QSSAPI.BLL;

namespace QSSAPI.DAL
{
    public class DAL_mstr_slu
    {
        public DataTable Bind_mstr_slu()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Bind_mstr_slu_API";
            cmd.CommandType = CommandType.StoredProcedure;

            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable Bind_mstr_sluByNumber(string number)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Bind_mstr_slu_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@slu_number", number);

            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable Bind_mstr_sluByName(string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Bind_mstr_slu_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", name);

            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public int Insert_mstr_slu(BOL_mstr_slu bol_mstr_slu)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert_mstr_slu";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@slu_number", bol_mstr_slu.slu_number);
            cmd.Parameters.AddWithValue("@slu_name", bol_mstr_slu.slu_name);
            cmd.Parameters.AddWithValue("@slu_style", bol_mstr_slu.slu_style);
            cmd.Parameters.AddWithValue("@slu_branchid", bol_mstr_slu.slu_branchid);
            cmd.Parameters.AddWithValue("@slu_inactive", bol_mstr_slu.slu_inactive);
            cmd.Parameters.AddWithValue("@slu_createdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@slu_createby", bol_mstr_slu.slu_createby);
            cmd.Parameters.AddWithValue("@slu_lastupdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@slu_updateby", bol_mstr_slu.slu_updateby);
         
            return SqlConjunction.GetSQLTransVoid(cmd);
        }
    }
}