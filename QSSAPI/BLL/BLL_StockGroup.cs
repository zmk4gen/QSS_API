using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using QSSAPI.DAL;
using QSSAPI.BOL;

namespace QSSAPI.BLL
{
    public class BLL_StockGroup
    {
        public DataTable BindStockGroup()
        {
            DAL_StockGroup dalStockGroup = new DAL_StockGroup();
            return dalStockGroup.BindStockGroup();
        }

        public DataTable BindStockGroupByCode(string code)
        {
            DAL_StockGroup dalStockGroup = new DAL_StockGroup();
            return dalStockGroup.BindStockGroupByCode(code);
        }

        public DataTable BindStockGroupByName(string name)
        {
            DAL_StockGroup dalStockGroup = new DAL_StockGroup();
            return dalStockGroup.BindStockGroupByName(name);
        }

        public int InsertStockGroup(BOL_StockGroup bolstockgroup)
        {
            int effectID = 0;
            try
            {
                SqlConjunction.StartTransaction();

                DAL_StockGroup dalstockgroup = new DAL_StockGroup();
                effectID = dalstockgroup.Insert_StockGroup(bolstockgroup);

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