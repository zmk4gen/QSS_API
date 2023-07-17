using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using QSSAPI.DAL;
using QSSAPI.BOL;


namespace QSSAPI.BLL
{
    public class BLL_Location
    {
        public DataTable BindLocation()
        {
            DAL_Location dalLocation = new DAL_Location();
            return dalLocation.BindLocation();
        }

        public DataTable BindLocationByCode(string code)
        {
            DAL_Location dalLocation = new DAL_Location();
            return dalLocation.BindLocationByNumber(code);
        }

        public DataTable BindLocationByName(string name)
        {
            DAL_Location dalLocation = new DAL_Location();
            return dalLocation.BindLocationByName(name);
        }

        public DataTable BindLocationByCodeANDName(string code,string name)
        {
            DAL_Location dalLocation = new DAL_Location();
            return dalLocation.BindLocationByCodeANDName(code, name);
        }

        public int InserLocation(BOL_Location bolLocation)
        {
            int effectID = 0;
            try
            {
                SqlConjunction.StartTransaction();

                DAL_Location dalLocation = new DAL_Location();
                effectID = dalLocation.Insert_Location(bolLocation);

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