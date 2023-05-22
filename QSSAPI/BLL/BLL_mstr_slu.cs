using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using QSSAPI.DAL;
using QSSAPI.BOL;

namespace QSSAPI.BLL
{
    public class BLL_mstr_slu
    {
        public DataTable Bind_mstr_slu()
        {
            DAL_mstr_slu dal_mstr_slu = new DAL_mstr_slu();
            return dal_mstr_slu.Bind_mstr_slu();
        }

        public DataTable Bind_mstr_sluByCode(string code)
        {
            DAL_mstr_slu dal_mstr_slu = new DAL_mstr_slu();
            return dal_mstr_slu.Bind_mstr_sluByNumber(code);
        }

        public DataTable Bind_mstr_sluByName(string name)
        {
            DAL_mstr_slu dal_mstr_slu = new DAL_mstr_slu();
            return dal_mstr_slu.Bind_mstr_sluByName(name);
        }

        public int Insert_mstr_slu(BOL_mstr_slu bol_mstr_slu)
        {
            int effectID = 0;
            try
            {
                SqlConjunction.StartTransaction();

                DAL_mstr_slu dal_mstr_slu = new DAL_mstr_slu();
                effectID = dal_mstr_slu.Insert_mstr_slu(bol_mstr_slu);

                SqlConjunction.CommitTransaction();
            }
            catch (Exception ex)
            {
                SqlConjunction.RollbackTransaction(ex.Message);

            }
            return effectID;
        }

        public int Update_mstr_slu(BOL_mstr_slu bol_mstr_slu)
        {
            int effectID = 0;
            try
            {
                SqlConjunction.StartTransaction();

                DAL_mstr_slu dal_mstr_slu = new DAL_mstr_slu();
                effectID = dal_mstr_slu.Update_mstr_slu(bol_mstr_slu);

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