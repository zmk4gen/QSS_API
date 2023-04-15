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
    public class DAL_Menu
    {
      
        /// <summary>
        /// Menu Item
        /// </summary>
        /// <returns></returns>
        public DataTable BindMenuitem()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindMenuitem_API";
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@stockno", "");
            //cmd.Parameters.AddWithValue("@Desc", "");
            cmd.Parameters.AddWithValue("@st_ingredient", true);
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable SelectbyMenuItem(string stockno)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindMenuitem_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@stockno", stockno);
            cmd.Parameters.AddWithValue("@st_ingredient", false);
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable SearchbyMenuItem(string desc)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindMenuitem_API";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Desc", desc);
            cmd.Parameters.AddWithValue("@st_ingredient", false);
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public int Insert_MenuItem(BOL_stock bol_menu)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "InsertStock_API";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@stock_no", bol_menu.stock_no);
            cmd.Parameters.AddWithValue("@stock_description", bol_menu.stock_description);
            cmd.Parameters.AddWithValue("@stock_description2", bol_menu.stock_description2);
            cmd.Parameters.AddWithValue("@stock_description3", bol_menu.stock_description3);
            cmd.Parameters.AddWithValue("@st_barcode", bol_menu.st_barcode);
            cmd.Parameters.AddWithValue("@st_cost", bol_menu.st_cost);
            cmd.Parameters.AddWithValue("@st_DeptID", bol_menu.st_DeptID);
            cmd.Parameters.AddWithValue("@st_StockGroupID", bol_menu.st_StockGroupID);
            cmd.Parameters.AddWithValue("@st_StockType", bol_menu.st_StockType);
            cmd.Parameters.AddWithValue("@st_ArticleNo", bol_menu.st_ArticleNo);
            cmd.Parameters.AddWithValue("@st_SuppID", bol_menu.st_SuppID);

            cmd.Parameters.AddWithValue("@st_OpenPrice", bol_menu.st_OpenPrice);
            cmd.Parameters.AddWithValue("@st_Obsolete", bol_menu.st_Obsolete);
            cmd.Parameters.AddWithValue("@st_allowNeg", bol_menu.st_allowNeg);
            cmd.Parameters.AddWithValue("@st_CP", bol_menu.st_CP);
            cmd.Parameters.AddWithValue("@st_Remarks", bol_menu.st_Remarks);
            cmd.Parameters.AddWithValue("@st_CreateBy", bol_menu.st_CreateBy);
            if (bol_menu.st_CreateDate == Helper.ConvertDateTime("01/01/0001"))
            {
                cmd.Parameters.AddWithValue("@st_CreateDate", DBNull.Value);
                cmd.Parameters.AddWithValue("@st_LastUpdate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@st_CreateDate", bol_menu.st_CreateDate);
                cmd.Parameters.AddWithValue("@st_LastUpdate", bol_menu.st_LastUpdate);
            }
            cmd.Parameters.AddWithValue("@st_Discount", bol_menu.st_Discount);
            cmd.Parameters.AddWithValue("@st_forSO", bol_menu.st_forSO);
            cmd.Parameters.AddWithValue("@st_taxid", bol_menu.st_taxid);
            cmd.Parameters.AddWithValue("@st_nluid", bol_menu.st_nluid);
            cmd.Parameters.AddWithValue("@st_sluid", bol_menu.st_sluid);
            cmd.Parameters.AddWithValue("@st_combo", bol_menu.st_combo);
            cmd.Parameters.AddWithValue("@st_combopattern", bol_menu.st_combopattern);
            cmd.Parameters.AddWithValue("@st_requireremarks", bol_menu.st_requireremarks);
            cmd.Parameters.AddWithValue("@st_discitemize", bol_menu.st_discitemize);
            cmd.Parameters.AddWithValue("@st_ServiceChargeID", bol_menu.st_ServiceChargeID);
            cmd.Parameters.AddWithValue("@st_effectivefrom", bol_menu.st_effectivefrom);
            cmd.Parameters.AddWithValue("@st_effectiveto", bol_menu.st_effectiveto);
            cmd.Parameters.AddWithValue("@st_effectivedate", bol_menu.st_effectivedate);
            cmd.Parameters.AddWithValue("@st_keyboardnumber", bol_menu.st_keyboardnumber);
            cmd.Parameters.AddWithValue("@st_printOnGuestCheck", bol_menu.st_printOnGuestCheck);
            cmd.Parameters.AddWithValue("@st_PrintOnReceipt", bol_menu.st_PrintOnReceipt);
            cmd.Parameters.AddWithValue("@st_menuprivilege", bol_menu.st_menuprivilege);
            cmd.Parameters.AddWithValue("@st_kdstimer", bol_menu.st_kdstimer);
            cmd.Parameters.AddWithValue("@st_pcscount", bol_menu.st_pcscount);
            cmd.Parameters.AddWithValue("@st_count", bol_menu.st_count);
            cmd.Parameters.AddWithValue("@st_fireonthefly", bol_menu.st_fireonthefly);
            cmd.Parameters.AddWithValue("@st_kdsgroup", bol_menu.st_kdsgroup);
            cmd.Parameters.AddWithValue("@st_UpdateBy", bol_menu.st_UpdateBy);
            return SqlConjunction.GetSQLTransVoid(cmd);
        }
    }
}