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
    public class DAL_StockQty
    {
        public DataTable BindStocksQty()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindStocksQty_API";
            cmd.CommandType = CommandType.StoredProcedure;

            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindStocksQtyByNumber(string number)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindStocksQty_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sq_stockid", number);

            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public int Insert_StocksQty(BOL_StocksQty bol_StocksQty)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "InsertStockQty";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@stock_id", bol_StocksQty.sq_stockid);
            cmd.Parameters.AddWithValue("@stock_no", bol_StocksQty.sq_sn);
            cmd.Parameters.AddWithValue("@sq_contain", bol_StocksQty.sq_contain);
            cmd.Parameters.AddWithValue("@sq_uom", bol_StocksQty.sq_uom);
            cmd.Parameters.AddWithValue("@sq_qty", bol_StocksQty.sq_qyt);
            cmd.Parameters.AddWithValue("@sq_location", bol_StocksQty.sq_locaiton);
            cmd.Parameters.AddWithValue("@branch_id", bol_StocksQty.sq_branchid);
            cmd.Parameters.AddWithValue("@sq_lastupdate", DateTime.Now);
           
            return SqlConjunction.GetSQLTransVoid(cmd);
        }
    }
}