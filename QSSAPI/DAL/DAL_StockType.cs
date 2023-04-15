using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using QSSAPI.BLL;
using QSSAPI.BOL;
namespace QSSAPI.DAL
{
    public class DAL_StockType
    {
        /// <summary>
        /// Report Group
        /// </summary>
        /// <returns></returns>
        public DataTable BindReportGroup()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindReportGroup_API";
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
        public DataTable BindReportGroupByName(string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindReportGroup_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", name);
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public int Insert_ReportGroup(BOL_StockType bol_stocktype)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert_Stock_Type_API";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@stype_Code", bol_stocktype.stype_Code);
            cmd.Parameters.AddWithValue("@stype_Name", bol_stocktype.stype_Name);
            cmd.Parameters.AddWithValue("@stype_Accno", bol_stocktype.stype_Accno);
            cmd.Parameters.AddWithValue("@stype_Inactive", bol_stocktype.stype_Inactive);
            cmd.Parameters.AddWithValue("@stype_LastUpdate", bol_stocktype.stype_LastUpdate);
            cmd.Parameters.AddWithValue("@stype_UpdateBy", bol_stocktype.stype_UpdateBy);
            cmd.Parameters.AddWithValue("@stype_createdate", bol_stocktype.stype_createdate);
            cmd.Parameters.AddWithValue("@stype_createby", bol_stocktype.stype_createby);
            return SqlConjunction.GetSQLTransVoid(cmd);
        }
    }
}