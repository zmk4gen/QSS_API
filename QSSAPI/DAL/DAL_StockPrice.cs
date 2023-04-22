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
    public class DAL_StockPrice
    {
        public DataTable BindStockPrice()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindStockPrice_API";
            cmd.CommandType = CommandType.StoredProcedure;

            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindStockPriceByNumber(string number)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindStockPrice_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pt_pgcode", number);

            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public int InsertStockPrice(BOL_StockPriceTable bol_stockpricetable)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "InsertStockPrice";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@stock_id", bol_stockpricetable.pt_stockid);
            cmd.Parameters.AddWithValue("@pt_sprice", bol_stockpricetable.pt_sprice);
            cmd.Parameters.AddWithValue("@pt_lastupdate", bol_stockpricetable.pt_lastupdate);
           
            return SqlConjunction.GetSQLTransVoid(cmd);
        }
    }
}