using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data;
using QSSAPI.BOL;
using QSSAPI.DAL;

namespace QSSAPI.BLL
{
    public class BLL_StockGroup
    {
        /// <summary>
        /// Family Group
        /// </summary>
        /// <returns></returns>
        public DataTable BindFamilyGroup()
        {
            DAL_StockGroup dalmenuitem = new DAL_StockGroup();
            return dalmenuitem.BindFamilyGroup();
        }
        public DataTable BindFamilyGroupByCode(string code)
        {
            DAL_StockGroup dalmenuitem = new DAL_StockGroup();
            return dalmenuitem.BindFamilyGroupByCode(code);
        }
        public DataTable BindFamilyGroupByName(string name)
        {
            DAL_StockGroup dalmenuitem = new DAL_StockGroup();
            return dalmenuitem.BindFamilyGroupByName(name);
        }

        public int InsertFamilyGroup(BOL_StockGroup bolstockgroup)
        {
            int effectID = 0;
            try
            {
                SqlConjunction.StartTransaction();

                DAL_StockGroup dalmenuitem = new DAL_StockGroup();
                effectID = dalmenuitem.Insert_FamilyGroup(bolstockgroup);

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