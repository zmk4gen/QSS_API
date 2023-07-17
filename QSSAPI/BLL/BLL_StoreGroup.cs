using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using QSSAPI.DAL;
using QSSAPI.BOL;

namespace QSSAPI.BLL
{
    public class BLL_StoreGroup
    {
        public DataTable BindStoreGroup()
        {
            DAL_StoreGroup dalStoreGroup = new DAL_StoreGroup();
            return dalStoreGroup.BindStoreGroup();
        }

        public DataTable BindStoreGroupByCode(string code)
        {
            DAL_StoreGroup dalStoreGroup = new DAL_StoreGroup();
            return dalStoreGroup.BindStoreGroupByNumber(code);
        }

        public DataTable BindStoreGroupByName(string name)
        {
            DAL_StoreGroup dalStoreGroup = new DAL_StoreGroup();
            return dalStoreGroup.BindStoreGroupByName(name);
        }

        public DataTable BindStoreGroupByCodeANDName(string code,string name)
        {
            DAL_StoreGroup dalStoreGroup = new DAL_StoreGroup();
            return dalStoreGroup.BindStoreGroupByCodeANDName(code, name);
        }

        public int InserStoreGroup(BOL_StoreGroup bolStoreGroup)
        {
            int effectID = 0;
            try
            {
                SqlConjunction.StartTransaction();

                DAL_StoreGroup dalStoreGroup = new DAL_StoreGroup();
                effectID = dalStoreGroup.Insert_StoreGroup(bolStoreGroup);

                SqlConjunction.CommitTransaction();
            }
            catch (Exception ex)
            {
                SqlConjunction.RollbackTransaction(ex.Message);

            }
            return effectID;
        }

        public int UpdateStoreGroup(BOL_StoreGroup bolStoreGroup)
        {
            int effectID = 0;
            try
            {
                SqlConjunction.StartTransaction();

                DAL_StoreGroup dalStoreGroup = new DAL_StoreGroup();
                effectID = dalStoreGroup.Update_StoreGroup(bolStoreGroup);

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