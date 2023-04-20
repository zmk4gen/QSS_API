using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using QSSAPI.DAL;
using QSSAPI.BOL;

namespace QSSAPI.BLL
{
    public class BLL_Condiment
    {
        public DataTable BindCondiment()
        {
            DAL_Condiment dalCondiment = new DAL_Condiment();
            return dalCondiment.BindCondiment();
        }

        public DataTable BindCondimentByCode(string code)
        {
            DAL_Condiment dalCondiment = new DAL_Condiment();
            return dalCondiment.BindCondimentByNumber(code);
        }

        public DataTable BindCondimentByName(string name)
        {
            DAL_Condiment dalCondiment = new DAL_Condiment();
            return dalCondiment.BindCondimentByName(name);
        }

        public int InserCondiment(BOL_Condiment bolCondiment)
        {
            int effectID = 0;
            try
            {
                SqlConjunction.StartTransaction();

                DAL_Condiment dalCondiment = new DAL_Condiment();
                effectID = dalCondiment.Insert_Condiment(bolCondiment);

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