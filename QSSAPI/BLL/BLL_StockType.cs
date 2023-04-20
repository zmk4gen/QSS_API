using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
<<<<<<< HEAD
using System.Data;
using QSSAPI.DAL;
using QSSAPI.BOL;

=======

using System.Data;
using QSSAPI.DAL;
using QSSAPI.BOL;
>>>>>>> 0dd232699496117e7f68fb51c4a4d687c5de24fe
namespace QSSAPI.BLL
{
    public class BLL_StockType
    {
<<<<<<< HEAD

        /// <summary>
        /// Report Group
        /// </summary>
        /// <returns></returns>
        public DataTable BindReportGroup()
        {
            DAL_StockType dalmenuitem = new DAL_StockType();
            return dalmenuitem.BindReportGroup();
        }
        public DataTable BindReportGroupByCode(string code)
        {
            DAL_StockType dalmenuitem = new DAL_StockType();
            return dalmenuitem.BindReportGroupByCode(code);
        }
        public DataTable BindReportGroupByDesc(string name)
        {
            DAL_StockType dalmenuitem = new DAL_StockType();
            return dalmenuitem.BindReportGroupByName(name);
        }
        public int InsertReportGroup(BOL_StockType bolstocktype)
=======
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
>>>>>>> 0dd232699496117e7f68fb51c4a4d687c5de24fe
        {
            int effectID = 0;
            try
            {
                SqlConjunction.StartTransaction();

<<<<<<< HEAD
                DAL_StockType dalmenuitem = new DAL_StockType();
                effectID = dalmenuitem.Insert_ReportGroup(bolstocktype);

                SqlConjunction.CommitTransaction();

=======
                DAL_StockType dalstocktype = new DAL_StockType();
                effectID = dalstocktype.Insert_StockType(bolstocktype);

                SqlConjunction.CommitTransaction();
>>>>>>> 0dd232699496117e7f68fb51c4a4d687c5de24fe
            }
            catch (Exception ex)
            {
                SqlConjunction.RollbackTransaction(ex.Message);
            }
            return effectID;
        }
<<<<<<< HEAD

=======
>>>>>>> 0dd232699496117e7f68fb51c4a4d687c5de24fe
    }
}