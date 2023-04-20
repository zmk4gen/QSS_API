using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using QSSAPI.BOL;
<<<<<<< HEAD

=======
using DAL;
>>>>>>> 0dd232699496117e7f68fb51c4a4d687c5de24fe

namespace QSSAPI.DAL
{
    public class DAL_StockGroup
    {
<<<<<<< HEAD
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
=======
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
>>>>>>> 0dd232699496117e7f68fb51c4a4d687c5de24fe
            cmd.Parameters.AddWithValue("@code", code);
            cmd.CommandType = CommandType.StoredProcedure;

            return SqlConjunction.GetSQLDataTable(cmd);
        }

<<<<<<< HEAD
        public DataTable BindFamilyGroupByName(string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindFamilyGroup_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", name);
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public int Insert_FamilyGroup(BOL_StockGroup bol_stockgroup)
=======
        public DataTable BindStockGroupByName(string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindStockGroup_API";
            cmd.Parameters.AddWithValue("@name", name);
            cmd.CommandType = CommandType.StoredProcedure;

            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public int Insert_StockGroup(BOL_StockGroup bol_stockGroup)
>>>>>>> 0dd232699496117e7f68fb51c4a4d687c5de24fe
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert_Stock_Group_API";
            cmd.CommandType = CommandType.StoredProcedure;

<<<<<<< HEAD
            cmd.Parameters.AddWithValue("@stype_Code", bol_stockgroup.sg_Code);
            cmd.Parameters.AddWithValue("@stype_Name", bol_stockgroup.sg_Name);
            cmd.Parameters.AddWithValue("@stype_Accno", bol_stockgroup.sg_Accno);
            cmd.Parameters.AddWithValue("@stype_Inactive", bol_stockgroup.sg_Inactive);
            cmd.Parameters.AddWithValue("@stype_LastUpdate", bol_stockgroup.sg_LastUpdate);
            cmd.Parameters.AddWithValue("@stype_UpdateBy", bol_stockgroup.sg_UpdateBy);
            cmd.Parameters.AddWithValue("@stype_createdate", bol_stockgroup.sg_createdate);
            cmd.Parameters.AddWithValue("@stype_createby", bol_stockgroup.sg_createby);
=======
            cmd.Parameters.AddWithValue("@sg_Code", bol_stockGroup.sg_Code);
            cmd.Parameters.AddWithValue("@sg_Name", bol_stockGroup.sg_Name);
            cmd.Parameters.AddWithValue("@sg_Accno", bol_stockGroup.sg_Accno);
            cmd.Parameters.AddWithValue("@sg_Inactive", bol_stockGroup.sg_Inactive);
            cmd.Parameters.AddWithValue("@sg_LastUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@sg_UpdateBy", bol_stockGroup.sg_UpdateBy);
            cmd.Parameters.AddWithValue("@sg_createdate", bol_stockGroup.sg_createdate);
            cmd.Parameters.AddWithValue("@sg_createby", DateTime.Now);

>>>>>>> 0dd232699496117e7f68fb51c4a4d687c5de24fe
            return SqlConjunction.GetSQLTransVoid(cmd);
        }
    }
}