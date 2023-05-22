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

        /// <summary>
        /// Family Group
        /// </summary>
        /// <returns></returns>
     
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

            cmd.Parameters.AddWithValue("@sg_Code", code);
            cmd.Parameters.AddWithValue("@status", "true");
            cmd.CommandType = CommandType.StoredProcedure;

            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindFamilyGroupByName(string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindFamilyGroup_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", name);
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindStockGroupByName(string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindStockGroup_API";
            cmd.Parameters.AddWithValue("@sg_Name", name);
            cmd.Parameters.AddWithValue("@status", "false");
            cmd.CommandType = CommandType.StoredProcedure;

            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public int Insert_StockGroup(BOL_StockGroup bol_stockGroup)

        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert_Stock_Group_API";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@stype_Code", bol_stockGroup.sg_Code);
            cmd.Parameters.AddWithValue("@stype_Name", bol_stockGroup.sg_Name);
            cmd.Parameters.AddWithValue("@stype_Accno", bol_stockGroup.sg_Accno);
            cmd.Parameters.AddWithValue("@stype_Inactive", bol_stockGroup.sg_Inactive);
            cmd.Parameters.AddWithValue("@stype_LastUpdate", bol_stockGroup.sg_LastUpdate);
            cmd.Parameters.AddWithValue("@stype_UpdateBy", bol_stockGroup.sg_UpdateBy);
            cmd.Parameters.AddWithValue("@stype_createdate", bol_stockGroup.sg_createdate);
            cmd.Parameters.AddWithValue("@stype_createby", bol_stockGroup.sg_createby);
            return SqlConjunction.GetSQLTransVoid(cmd);
        }

        public int Update_StockGroup(BOL_StockGroup bol_stockGroup)

        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UpdateStockGroup";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@stype_Code", bol_stockGroup.sg_Code);
            cmd.Parameters.AddWithValue("@stype_Name", bol_stockGroup.sg_Name);
            cmd.Parameters.AddWithValue("@stype_Accno", bol_stockGroup.sg_Accno);
            cmd.Parameters.AddWithValue("@stype_Inactive", bol_stockGroup.sg_Inactive);
            cmd.Parameters.AddWithValue("@stype_LastUpdate", bol_stockGroup.sg_LastUpdate);
            cmd.Parameters.AddWithValue("@stype_UpdateBy", bol_stockGroup.sg_UpdateBy);
            cmd.Parameters.AddWithValue("@stype_createdate", bol_stockGroup.sg_createdate);
            cmd.Parameters.AddWithValue("@stype_createby", bol_stockGroup.sg_createby);
            return SqlConjunction.GetSQLTransVoid(cmd);
        }
    }
}