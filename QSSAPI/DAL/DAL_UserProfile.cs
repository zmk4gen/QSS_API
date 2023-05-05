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
    public class DAL_UserProfile
    {
        public DataTable BindUserProfile()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindUserProfile_API";
            cmd.CommandType = CommandType.StoredProcedure;
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindUserProfileByNumber(string number)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindUserProfile_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cond_number", number);

            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindUserProfileByName(string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindUserProfile_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", name);
            return SqlConjunction.GetSQLDataTable(cmd);
        }
        public int Insert_UserProfile(BOL_UserProfile bol_UserProfile)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert_UserProfile";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@up_ID", bol_UserProfile.up_ID);
            cmd.Parameters.AddWithValue("@up_Name", bol_UserProfile.up_Name);
            cmd.Parameters.AddWithValue("@up_pmuploaded", bol_UserProfile.up_pumploaded);
            cmd.Parameters.AddWithValue("@up_createdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@up_createby", bol_UserProfile.up_createby);
            cmd.Parameters.AddWithValue("@up_lastupdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@up_updateby", bol_UserProfile.up_updateby);
            cmd.Parameters.AddWithValue("@up_inactive", bol_UserProfile.up_inactive);
            cmd.Parameters.AddWithValue("@up_localmaintain", bol_UserProfile.up_localmaintain);
            cmd.Parameters.AddWithValue("@up_typedef", bol_UserProfile.up_typedef);
            
            return SqlConjunction.GetSQLTransVoid(cmd);
        }
    }
}