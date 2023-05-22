using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using QSSAPI.DAL;
using QSSAPI.BOL;

namespace QSSAPI.BLL
{
    public class BLL_MasterComboGroup
    {
        public DataTable BindMasterComboGroup()
        {
            DAL_MasterComboGroup dalMasterComboGroup = new DAL_MasterComboGroup();
            return dalMasterComboGroup.BindMasterComboGroup();
        }

        public DataTable BindMasterComboGroupByCode(string code)
        {
            DAL_MasterComboGroup dalMasterComboGroup = new DAL_MasterComboGroup();
            return dalMasterComboGroup.BindMasterComboGroupByNumber(code);
        }

        public DataTable BindMasterComboGroupByName(string name)
        {
            DAL_MasterComboGroup dalMasterComboGroup = new DAL_MasterComboGroup();
            return dalMasterComboGroup.BindMasterComboGroupByName(name);
        }

        public int InserMasterComboGroup(BOL_Master_Combogroup bolMasterComboGroup)
        {
            int effectID = 0;
            try
            {
                SqlConjunction.StartTransaction();

                DAL_MasterComboGroup dalMasterComboGroup = new DAL_MasterComboGroup();
                effectID = dalMasterComboGroup.Insert_MasterComboGroup(bolMasterComboGroup);

                SqlConjunction.CommitTransaction();
            }
            catch (Exception ex)
            {
                SqlConjunction.RollbackTransaction(ex.Message);

            }
            return effectID;
        }

        public int UpdateMasterComboGroup(BOL_Master_Combogroup bolMasterComboGroup)
        {
            int effectID = 0;
            try
            {
                SqlConjunction.StartTransaction();

                DAL_MasterComboGroup dalMasterComboGroup = new DAL_MasterComboGroup();
                effectID = dalMasterComboGroup.Update_MasterComboGroup(bolMasterComboGroup);

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