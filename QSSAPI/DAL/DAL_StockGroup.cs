using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using QSSAPI.BOL;


namespace QSSAPI.DAL
{
    public class DAL_StockGroup
    {
        /// <summary>
        /// Family Group
        /// </summary>
        /// <returns></returns>
        public DataTable BindFamilyGroup()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindFamilyGroup_API";
            cmd.CommandType = CommandType.StoredProcedure;
            return SqlConjunction.GetSQLDataTable(cmd);
        }
        public DataTable BindFamilyGroupByCode(string code)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindFamilyGroup_API";
            cmd.Parameters.AddWithValue("@code", code);
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

        public int Insert_FamilyGroup(BOL_StockGroup bol_stockgroup)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert_Stock_Group_API";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@stype_Code", bol_stockgroup.sg_Code);
            cmd.Parameters.AddWithValue("@stype_Name", bol_stockgroup.sg_Name);
            cmd.Parameters.AddWithValue("@stype_Accno", bol_stockgroup.sg_Accno);
            cmd.Parameters.AddWithValue("@stype_Inactive", bol_stockgroup.sg_Inactive);
            cmd.Parameters.AddWithValue("@stype_LastUpdate", bol_stockgroup.sg_LastUpdate);
            cmd.Parameters.AddWithValue("@stype_UpdateBy", bol_stockgroup.sg_UpdateBy);
            cmd.Parameters.AddWithValue("@stype_createdate", bol_stockgroup.sg_createdate);
            cmd.Parameters.AddWithValue("@stype_createby", bol_stockgroup.sg_createby);
            return SqlConjunction.GetSQLTransVoid(cmd);
        }
    }
}