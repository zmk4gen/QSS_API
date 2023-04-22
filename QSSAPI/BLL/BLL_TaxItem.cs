using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using QSSAPI.DAL;
using QSSAPI.BOL;

namespace QSSAPI.BLL
{
    public class BLL_TaxItem
    {
        public DataTable BindTaxItem()
        {
            DAL_TaxItem dalTaxItem = new DAL_TaxItem();
            return dalTaxItem.BindTaxItem();
        }

        public DataTable BindTaxItemByCode(string code)
        {
            DAL_TaxItem dalTaxItem = new DAL_TaxItem();
            return dalTaxItem.BindTaxItemByNumber(code);
        }

        public int InserTaxItem(BOL_TaxItem bolTaxItem)
        {
            int effectID = 0;
            try
            {
                SqlConjunction.StartTransaction();

                DAL_TaxItem dalTaxItem = new DAL_TaxItem();
                effectID = dalTaxItem.Insert_TaxItem(bolTaxItem);

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