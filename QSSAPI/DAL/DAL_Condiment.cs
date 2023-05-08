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
    public class DAL_Condiment
    {
        public DataTable BindCondiment()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindCondiment_API";
            cmd.CommandType = CommandType.StoredProcedure;
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindCondimentByNumber(string number)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindCondiment_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cond_number", number);

            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindCondimentByName(string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindCondiment_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", name);
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public int Insert_Condiment(BOL_Condiment bol_Condiment)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "InsertCondiment";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@cond_number", bol_Condiment.cond_number);
            cmd.Parameters.AddWithValue("@cond_name1", bol_Condiment.cond_name1);
            cmd.Parameters.AddWithValue("@cond_name2", bol_Condiment.cond_name2);
            cmd.Parameters.AddWithValue("@cond_name3", bol_Condiment.cond_name3);
            cmd.Parameters.AddWithValue("@cond_qty", bol_Condiment.cond_qty);
            cmd.Parameters.AddWithValue("@cond_style", bol_Condiment.cond_style);
            cmd.Parameters.AddWithValue("@cond_hhtstyle", bol_Condiment.cond_hhtstyle);
            cmd.Parameters.AddWithValue("@cond_typedef", bol_Condiment.cond_typedef);
            cmd.Parameters.AddWithValue("@cond_inactive", bol_Condiment.cond_inactive);
            cmd.Parameters.AddWithValue("@cond_createdate",DateTime.Now);
            cmd.Parameters.AddWithValue("@cond_createby", bol_Condiment.cond_createby);
            cmd.Parameters.AddWithValue("@cond_lastupdate",DateTime.Now);
            cmd.Parameters.AddWithValue("@cond_updateby", bol_Condiment.cond_updateby);
            cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
            return SqlConjunction.GetSQLTransVoid(cmd);
        }
    }
}