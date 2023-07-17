using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using QSSAPI.DAL;
using QSSAPI.BOL;

namespace QSSAPI.BLL
{
    public class BLL_UserProfile
    {
        public DataTable BindUserProfile()
        {
            DAL_UserProfile dalUserProfile = new DAL_UserProfile();
            return dalUserProfile.BindUserProfile();
        }

        public DataTable BindUserProfileByCode(string code)
        {
            DAL_UserProfile dalUserProfile = new DAL_UserProfile();
            return dalUserProfile.BindUserProfileByNumber(code);
        }

        public DataTable BindUserProfileByName(string name)
        {
            DAL_UserProfile dalUserProfile = new DAL_UserProfile();
            return dalUserProfile.BindUserProfileByName(name);
        }

        public DataTable BindUserProfileByCodeANDName(string code, string name)
        {
            DAL_UserProfile dalUserProfile = new DAL_UserProfile();
            return dalUserProfile.BindUserProfileByCodeANDName(code, name);
        }

        public int InserUserProfile(BOL_UserProfile bolUserProfile)
        {
            int effectID = 0;
            try
            {
                SqlConjunction.StartTransaction();

                DAL_UserProfile dalUserProfile = new DAL_UserProfile();
                effectID = dalUserProfile.Insert_UserProfile(bolUserProfile);

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