using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using QSSAPI.BOL;
using DAL;

namespace QSSAPI.DAL
{
    public class DAL_UserInfo
    {
        public DataTable BindUserInfo()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindUserInfo_API";
            cmd.CommandType = CommandType.StoredProcedure;
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindUserInfoByNumber(string number)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindUserInfo_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ui_id", number);
            cmd.Parameters.AddWithValue("@status", "true");
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindUserInfoByName(string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindUserInfo_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ui_name", name);
            cmd.Parameters.AddWithValue("@status", "false");
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindUserInfoByCodeANDName(string code, string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindUserInfo_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ui_id", code);
            cmd.Parameters.AddWithValue("@ui_name", name);
            cmd.Parameters.AddWithValue("@status", "false");
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public int Insert_UserInfo(BOL_UserInfo bol_userInfo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "InsertUserInfo";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ui_id", bol_userInfo.ui_id);
            cmd.Parameters.AddWithValue("@ui_code", bol_userInfo.ui_code);
            cmd.Parameters.AddWithValue("@ui_name", bol_userInfo.ui_name);
            cmd.Parameters.AddWithValue("@ui_password", bol_userInfo.ui_password);
            cmd.Parameters.AddWithValue("@ui_profileID", bol_userInfo.ui_profileID);
            cmd.Parameters.AddWithValue("@ui_countryID", bol_userInfo.ui_countryID);
            cmd.Parameters.AddWithValue("@ui_logon", bol_userInfo.ui_logon);
            cmd.Parameters.AddWithValue("@ui_branchID", bol_userInfo.ui_branchID);
            cmd.Parameters.AddWithValue("@ui_ValidFrom", bol_userInfo.ui_ValidFrom);
            cmd.Parameters.AddWithValue("@ui_ValidTo", bol_userInfo.ui_ValidTo);
            cmd.Parameters.AddWithValue("@ui_DocNo", bol_userInfo.ui_DocNo);
            cmd.Parameters.AddWithValue("@ui_onbehalf", bol_userInfo.ui_onbehalf);
            cmd.Parameters.AddWithValue("@ui_createby", bol_userInfo.ui_createby);
            cmd.Parameters.AddWithValue("@ui_createdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@ui_updateby", bol_userInfo.ui_updateby);
            cmd.Parameters.AddWithValue("@ui_lastupdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@ui_inactive", bol_userInfo.ui_inactive);
            cmd.Parameters.AddWithValue("@ui_telno", bol_userInfo.ui_telno);
            cmd.Parameters.AddWithValue("@ui_email", bol_userInfo.ui_email);
            cmd.Parameters.AddWithValue("@ui_address1", bol_userInfo.ui_address1);
            cmd.Parameters.AddWithValue("@ui_address2", bol_userInfo.ui_address2);
            cmd.Parameters.AddWithValue("@ui_address3", bol_userInfo.ui_address3);
            cmd.Parameters.AddWithValue("@ui_password2", bol_userInfo.ui_password2);
            cmd.Parameters.AddWithValue("@ui_ishq", bol_userInfo.ui_ishq);
            cmd.Parameters.AddWithValue("@ui_fingerprintTemplate", bol_userInfo.ui_fingerprint);
            cmd.Parameters.AddWithValue("@ui_lastfield", bol_userInfo.ui_lastfield);
            cmd.Parameters.AddWithValue("@ui_OCLimitDaily", bol_userInfo.ui_OCLimitDaily);
            cmd.Parameters.AddWithValue("@ui_OCLimitMonthly", bol_userInfo.ui_OCLimitMonthly);
            cmd.Parameters.AddWithValue("@ui_ENTLimitDaily", bol_userInfo.ui_ENTLimitDaily);
            cmd.Parameters.AddWithValue("@ui_ENTLimitMonthly", bol_userInfo.ui_ENTLimitMonthly);
            cmd.Parameters.AddWithValue("@ui_UserDepartment", bol_userInfo.ui_UserDepartment);
            cmd.Parameters.AddWithValue("@ui_globaluser", bol_userInfo.ui_globaluser);
            cmd.Parameters.AddWithValue("@ui_OCAmtDaily", bol_userInfo.ui_OCAmtDaily);
            cmd.Parameters.AddWithValue("@ui_OCAmt1", bol_userInfo.ui_OCAmt1);
            cmd.Parameters.AddWithValue("@ui_OCAmt2", bol_userInfo.ui_OCAmt2);
            cmd.Parameters.AddWithValue("@ui_OCAmt3", bol_userInfo.ui_OCAmt3);
            cmd.Parameters.AddWithValue("@ui_OCAmt4", bol_userInfo.ui_OCAmt4);
            cmd.Parameters.AddWithValue("@ui_OCAmt5", bol_userInfo.ui_OCAmt5);
            cmd.Parameters.AddWithValue("@ui_OCAmt6", bol_userInfo.ui_OCAmt6);
            cmd.Parameters.AddWithValue("@ui_OCAmt7", bol_userInfo.ui_OCAmt7);
            cmd.Parameters.AddWithValue("@ui_OCAmt8", bol_userInfo.ui_OCAmt8);
            cmd.Parameters.AddWithValue("@ui_OCAmt9", bol_userInfo.ui_OCAmt9);
            cmd.Parameters.AddWithValue("@ui_OCAmt10", bol_userInfo.ui_OCAmt10);
            cmd.Parameters.AddWithValue("@ui_OCAmt11", bol_userInfo.ui_OCAmt11);
            cmd.Parameters.AddWithValue("@ui_OCAmt12", bol_userInfo.ui_OCAmt12);
            cmd.Parameters.AddWithValue("@ui_ENTAmtDaily", bol_userInfo.ui_ENTAmtDaily);
            cmd.Parameters.AddWithValue("@ui_ENTAmt1", bol_userInfo.ui_ENTAmt1);
            cmd.Parameters.AddWithValue("@ui_ENTAmt2", bol_userInfo.ui_ENTAmt2);
            cmd.Parameters.AddWithValue("@ui_ENTAmt3", bol_userInfo.ui_ENTAmt3);
            cmd.Parameters.AddWithValue("@ui_ENTAmt4", bol_userInfo.ui_ENTAmt4);
            cmd.Parameters.AddWithValue("@ui_ENTAmt5", bol_userInfo.ui_ENTAmt5);
            cmd.Parameters.AddWithValue("@ui_ENTAmt6", bol_userInfo.ui_ENTAmt6);
            cmd.Parameters.AddWithValue("@ui_ENTAmt7", bol_userInfo.ui_ENTAmt7);
            cmd.Parameters.AddWithValue("@ui_ENTAmt8", bol_userInfo.ui_ENTAmt8);
            cmd.Parameters.AddWithValue("@ui_ENTAmt9", bol_userInfo.ui_ENTAmt9);
            cmd.Parameters.AddWithValue("@ui_ENTAmt10", bol_userInfo.ui_ENTAmt10);
            cmd.Parameters.AddWithValue("@ui_ENTAmt11", bol_userInfo.ui_ENTAmt11);
            cmd.Parameters.AddWithValue("@ui_ENTAmt12", bol_userInfo.ui_ENTAmt12);
            cmd.Parameters.AddWithValue("@ui_syncOCENTlastupdate", bol_userInfo.ui_synOCENTlastupdate);
            cmd.Parameters.AddWithValue("@ui_training", bol_userInfo.ui_training);
            cmd.Parameters.AddWithValue("@ui_uploadPWD", bol_userInfo.ui_uploadPWD);
            
            return SqlConjunction.GetSQLTransVoid(cmd);
        }
    }
}