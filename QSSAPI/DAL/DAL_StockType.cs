using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
<<<<<<< HEAD
using QSSAPI.BLL;
using QSSAPI.BOL;
=======
using QSSAPI.BOL;
using DAL;

>>>>>>> 0dd232699496117e7f68fb51c4a4d687c5de24fe
namespace QSSAPI.DAL
{
    public class DAL_StockType
    {
<<<<<<< HEAD
        /// <summary>
        /// Report Group
        /// </summary>
        /// <returns></returns>
        public DataTable BindReportGroup()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindReportGroup_API";
=======
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
>>>>>>> 0dd232699496117e7f68fb51c4a4d687c5de24fe
            cmd.CommandType = CommandType.StoredProcedure;

            return SqlConjunction.GetSQLDataTable(cmd);
        }
<<<<<<< HEAD
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
=======
        public DataTable BindStockTypeByName(string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindStockType_API";
>>>>>>> 0dd232699496117e7f68fb51c4a4d687c5de24fe
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", name);
            return SqlConjunction.GetSQLDataTable(cmd);
        }
<<<<<<< HEAD

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
=======
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

>>>>>>> 0dd232699496117e7f68fb51c4a4d687c5de24fe
            return SqlConjunction.GetSQLTransVoid(cmd);
        }
    }
}