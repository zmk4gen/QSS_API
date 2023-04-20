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

        /// <summary>
        /// Report Group
        /// </summary>
        /// <returns></returns>
        //public DataTable BindReportGroup()
        //{
        //    DAL_StockType dalmenuitem = new DAL_StockType();
        //    return dalmenuitem.BindReportGroup();
        //}
        //public DataTable BindReportGroupByCode(string code)
        //{
        //    DAL_StockType dalmenuitem = new DAL_StockType();
        //    return dalmenuitem.BindReportGroupByCode(code);
        //}
        //public DataTable BindReportGroupByDesc(string name)
        //{
        //    DAL_StockType dalmenuitem = new DAL_StockType();
        //    return dalmenuitem.BindReportGroupByName(name);
        //}

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

                DAL_StockType dalmenuitem = new DAL_StockType();
                effectID = dalmenuitem.Insert_StockType(bolstocktype);

                SqlConjunction.CommitTransaction();


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