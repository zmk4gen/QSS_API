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
    public class DAL_TaxItem
    {
        public DataTable BindTaxItem()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindTaxItem_API";
            cmd.CommandType = CommandType.StoredProcedure;

            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindTaxItemByNumber(string number)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindTaxItem_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@taxitem_stockid", number);

            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public int Insert_TaxItem(BOL_TaxItem bol_TaxItem)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert_TaxItem";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@stock_id", bol_TaxItem.taxitem_stockid);
            cmd.Parameters.AddWithValue("@taxitem_id", bol_TaxItem.taxitem_id);
            cmd.Parameters.AddWithValue("@created_date", DateTime.Now);
            cmd.Parameters.AddWithValue("@crated_by", bol_TaxItem.taxitem_createby);
            
            return SqlConjunction.GetSQLTransVoid(cmd);
        }
    }
}