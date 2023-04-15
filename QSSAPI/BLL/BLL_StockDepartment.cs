using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using QSSAPI.DAL;
using QSSAPI.BOL;
namespace QSSAPI.BLL
{
    public class BLL_StockDepartment
    {
        /// <summary>
        /// 
        /// Major Group
        /// </summary>
        /// <returns></returns>
        public DataTable BindMajorGroup()
        {
            DAL_StocckDepartment dalmenuitem = new DAL_StocckDepartment();
            return dalmenuitem.BindMajorGroup();
        }

        public DataTable BindMajorGroupByCode(string code)
        {
            DAL_StocckDepartment dalmenuitem = new DAL_StocckDepartment();
            return dalmenuitem.BindMajorGroupByCode(code);
        }
        public DataTable BindMajorGroupByName(string name)
        {
            DAL_StocckDepartment dalmenuitem = new DAL_StocckDepartment();
            return dalmenuitem.BindMajorGroupByName(name);
        }

        public int InsertMajorGroup(BOL_StockDepartment bolmenuitem)
        {
            int effectID = 0;
            try
            {
                SqlConjunction.StartTransaction();

                DAL_StocckDepartment dalmenuitem = new DAL_StocckDepartment();
                effectID = dalmenuitem.Insert_MajorGroup(bolmenuitem);

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