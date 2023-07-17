using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using QSSAPI.DAL;
using QSSAPI.BOL;

namespace QSSAPI.BLL
{
    public class BLL_ClockoutReason
    {
        public DataTable BindClockoutReason()
        {
            DAL_ClockoutReason dalClockoutReason = new DAL_ClockoutReason();
            return dalClockoutReason.BindClockoutReason();
        }

        public DataTable BindClockoutReasonByCode(string code)
        {
            DAL_ClockoutReason dalClockoutReason = new DAL_ClockoutReason();
            return dalClockoutReason.BindClockoutReasonByNumber(code);
        }

        public DataTable BindClockoutReasonByName(string name)
        {
            DAL_ClockoutReason dalClockoutReason = new DAL_ClockoutReason();
            return dalClockoutReason.BindClockoutReasonByName(name);
        }

        public DataTable BindClockoutReasonByCodeANDName(string code, string name)
        {
            DAL_ClockoutReason dalClockoutReason = new DAL_ClockoutReason();
            return dalClockoutReason.BindClockoutReasonByCodeANDName(code, name);
        }

        public int InserClockoutReason(BOL_ClockoutReason bolClockoutReason)
        {
            int effectID = 0;
            try
            {
                SqlConjunction.StartTransaction();

                DAL_ClockoutReason dalClockoutReason = new DAL_ClockoutReason();
                effectID = dalClockoutReason.Insert_ClockoutReason(bolClockoutReason);

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