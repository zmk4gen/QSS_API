using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using QSSAPI.DAL;
using QSSAPI.BOL;


namespace QSSAPI.BLL
{
    public class BLL_StockPrice
    {
        public DataTable BindStockPrice()
        {
            DAL_StockPrice dalStockPrice = new DAL_StockPrice();
            return dalStockPrice.BindStockPrice();
        }

        public DataTable BindStockPriceByCode(string code)
        {
            DAL_StockPrice dalStockPrice = new DAL_StockPrice();
            return dalStockPrice.BindStockPriceByNumber(code);
        }
        public int InserStockPrice(BOL_StockPriceTable bolStockPrice)
        {
            int effectID = 0;
            try
            {
                SqlConjunction.StartTransaction();

                DAL_StockPrice dalStockPrice = new DAL_StockPrice();
                effectID = dalStockPrice.InsertStockPrice(bolStockPrice);

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