using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using QSSAPI.DAL;
using QSSAPI.BOL;
namespace QSSAPI.BLL
{
    public class BLL_StockType
    {
        public DataTable BindStockType()
        {
            DAL_StockType dalStockType = new DAL_StockType();
            return dalStockType.BindStockType();
        }

        public DataTable BindStockTypeByCode(string code)
        {
            DAL_StockType dalStockType = new DAL_StockType();
            return dalStockType.BindStockTypeByCode(code);
        }

        public DataTable BindStockTypeByName(string name)
        {
            DAL_StockType dalstocktype = new DAL_StockType();
            return dalstocktype.BindStockTypeByName(name);
        }

        public int InsertStockType(BOL_StockType bolstocktype)
        {
            int effectID = 0;
            try
            {
                SqlConjunction.StartTransaction();

                DAL_StockType dalstocktype = new DAL_StockType();
                effectID = dalstocktype.Insert_StockType(bolstocktype);

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