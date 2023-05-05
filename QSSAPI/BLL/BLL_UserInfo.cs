using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using QSSAPI.DAL;
using QSSAPI.BOL;

namespace QSSAPI.BLL
{
    public class BLL_UserInfo
    {
        public DataTable BindUserInfo()
        {
            DAL_UserInfo dalUserInfo = new DAL_UserInfo();
            return dalUserInfo.BindUserInfo();
        }

        public DataTable BindUserInfoByCode(string code)
        {
            DAL_UserInfo dalUserInfo = new DAL_UserInfo();
            return dalUserInfo.BindUserInfoByNumber(code);
        }

        public DataTable BindUserInfoByName(string name)
        {
            DAL_UserInfo dalUserInfo = new DAL_UserInfo();
            return dalUserInfo.BindUserInfoByName(name);
        }

        public int InserUserInfo(BOL_UserInfo bolUserInfo)
        {
            int effectID = 0;
            try
            {
                SqlConjunction.StartTransaction();

                DAL_UserInfo dalUserInfo = new DAL_UserInfo();
                effectID = dalUserInfo.Insert_UserInfo(bolUserInfo);

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