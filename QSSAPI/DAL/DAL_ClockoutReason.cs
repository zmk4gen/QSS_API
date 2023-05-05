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
    public class DAL_ClockoutReason
    {
        public DataTable BindClockoutReason()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindClockoutReason_API";
            cmd.CommandType = CommandType.StoredProcedure;
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindClockoutReasonByNumber(string number)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindClockoutReason_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cor_Code", number);

            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindClockoutReasonByName(string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindClockoutReason_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cor_name", name);
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public int Insert_ClockoutReason(BOL_ClockoutReason bol_ClockoutReason)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "InsertClockoutReason";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@cor_ID", bol_ClockoutReason.cor_ID);
            cmd.Parameters.AddWithValue("@cor_Code", bol_ClockoutReason.cor_Code);
            cmd.Parameters.AddWithValue("@cor_Name", bol_ClockoutReason.cor_Name);
            cmd.Parameters.AddWithValue("@cor_LastUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@cor_updateby", bol_ClockoutReason.cor_updateby);
            cmd.Parameters.AddWithValue("@cor_createby", bol_ClockoutReason.cor_createby);
            cmd.Parameters.AddWithValue("@cor_createdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@cor_inactive", bol_ClockoutReason.cor_inactive);
            cmd.Parameters.AddWithValue("@cor_workingtime", bol_ClockoutReason.cor_workingtime);
            cmd.Parameters.AddWithValue("@cor_endshift", bol_ClockoutReason.cor_endshift);
            
            return SqlConjunction.GetSQLTransVoid(cmd);
        }
    }
}