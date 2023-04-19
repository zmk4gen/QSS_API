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
    public class DAL_StockGroup
    {
        public DataTable BindStockGroup()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindStockGroup_API";
            cmd.CommandType = CommandType.StoredProcedure;
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindStockGroupByCode(string code)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindStockGroup_API";
            cmd.Parameters.AddWithValue("@code", code);
            cmd.CommandType = CommandType.StoredProcedure;

            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindStockGroupByName(string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindStockGroup_API";
            cmd.Parameters.AddWithValue("@name", name);
            cmd.CommandType = CommandType.StoredProcedure;

            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public int Insert_StockGroup(BOL_StockGroup bol_stockGroup)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert_Stock_Group_API";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@sg_Code", bol_stockGroup.sg_Code);
            cmd.Parameters.AddWithValue("@sg_Name", bol_stockGroup.sg_Name);
            cmd.Parameters.AddWithValue("@sg_Accno", bol_stockGroup.sg_Accno);
            cmd.Parameters.AddWithValue("@sg_Inactive", bol_stockGroup.sg_Inactive);
            cmd.Parameters.AddWithValue("@sg_LastUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@sg_UpdateBy", bol_stockGroup.sg_UpdateBy);
            cmd.Parameters.AddWithValue("@sg_createdate", bol_stockGroup.sg_createdate);
            cmd.Parameters.AddWithValue("@sg_createby", DateTime.Now);

            return SqlConjunction.GetSQLTransVoid(cmd);
        }
    }
}