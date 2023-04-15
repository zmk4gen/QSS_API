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
        {
            int effectID = 0;
            try
            {
                SqlConjunction.StartTransaction();

                DAL_StockType dalmenuitem = new DAL_StockType();
                effectID = dalmenuitem.Insert_ReportGroup(bolstocktype);

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