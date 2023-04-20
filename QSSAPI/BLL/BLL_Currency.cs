using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using QSSAPI.DAL;
using QSSAPI.BOL;


namespace QSSAPI.BLL
{
    public class BLL_Currency
    {
        public DataTable BindCurrency()
        {
            DAL_Currency dalCurrency = new DAL_Currency();
            return dalCurrency.BindCurrency();
        }

        public DataTable BindCurrencyByCode(string code)
        {
            DAL_Currency dalCurrency = new DAL_Currency();
            return dalCurrency.BindCurrencyByNumber(code);
        }

        public DataTable BindCurrencyByName(string name)
        {
            DAL_Currency dalCurrency = new DAL_Currency();
            return dalCurrency.BindCurrencyByName(name);
        }

        public int InserCurrency(BOL_Currency bolCurrency)
        {
            int effectID = 0;
            try
            {
                SqlConjunction.StartTransaction();

                DAL_Currency dalCurrency = new DAL_Currency();
                effectID = dalCurrency.Insert_Currency(bolCurrency);

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