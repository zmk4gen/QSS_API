using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

using QSSAPI.BLL;
using QSSAPI.BOL;

using DAL;

namespace QSSAPI.DAL
{
    public class DAL_StockType
    {

        /// <summary>
        /// Report Group
        /// </summary>
        /// <returns></returns>
 
        public DataTable BindStockType()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindStockType_API";
            cmd.CommandType = CommandType.StoredProcedure;
            return SqlConjunction.GetSQLDataTable(cmd);
        }
        public DataTable BindStockTypeByCode(string code)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindStockType_API";
            cmd.Parameters.AddWithValue("@code", code);
            cmd.CommandType = CommandType.StoredProcedure;

            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindReportGroupByCode(string code)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindReportGroup_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@code", code);
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindStockTypeByName(string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindStockType_API";

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", name);
            return SqlConjunction.GetSQLDataTable(cmd);
        }


       public int Insert_StockType(BOL_StockType bol_stockType)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert_Stock_Type";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@stype_Code", bol_stockType.stype_Code);
            cmd.Parameters.AddWithValue("@stype_Name", bol_stockType.stype_Name);
            cmd.Parameters.AddWithValue("@stype_Accno", bol_stockType.stype_Accno);
            cmd.Parameters.AddWithValue("@stype_Inactive", bol_stockType.stype_Inactive);
            cmd.Parameters.AddWithValue("@stype_UpdateBy", bol_stockType.stype_UpdateBy);
            cmd.Parameters.AddWithValue("@stype_createby", bol_stockType.stype_createby);
            cmd.Parameters.AddWithValue("@stype_createdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@stype_LastUpdate", DateTime.Now);

            return SqlConjunction.GetSQLTransVoid(cmd);
        }
    }
}