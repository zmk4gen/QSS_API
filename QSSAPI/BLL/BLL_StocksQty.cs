using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using QSSAPI.DAL;
using QSSAPI.BOL;

namespace QSSAPI.BLL
{
    public class BLL_StocksQty
    {
        public DataTable BindStocksQty()
        {
            DAL_StockQty dalStocksQty = new DAL_StockQty();
            return dalStocksQty.BindStocksQty();
        }

        public DataTable BindStocksQtyByCode(string code)
        {
            DAL_StockQty dalStocksQty = new DAL_StockQty();
            return dalStocksQty.BindStocksQtyByNumber(code);
        }

        public int InserStocksQty(BOL_StocksQty bolStocksQty)
        {
            int effectID = 0;
            try
            {
                SqlConjunction.StartTransaction();

                DAL_StockQty dalStocksQty = new DAL_StockQty();
                effectID = dalStocksQty.Insert_StocksQty(bolStocksQty);

                SqlConjunction.CommitTransaction();
            }
            catch (Exception ex)
            {
                SqlConjunction.RollbackTransaction(ex.Message);

            }
            return effectID;
        }
    }
}