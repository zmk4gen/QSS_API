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
    public class DAL_MasterComboGroup
    {
        public DataTable BindMasterComboGroup()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindMasterComboGroup_API";
            cmd.CommandType = CommandType.StoredProcedure;
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindMasterComboGroupByNumber(string number)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindMasterComboGroup_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cbo_number", number);
            cmd.Parameters.AddWithValue("@status", "true");

            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindMasterComboGroupByName(string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindMasterComboGroup_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cbo_name", name);
            cmd.Parameters.AddWithValue("@status", "false");
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public int Insert_MasterComboGroup(BOL_Master_Combogroup bol_MasterComboGroup)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert_mstr_combogroup";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@cbo_number", bol_MasterComboGroup.cbo_number);
            cmd.Parameters.AddWithValue("@cbo_name", bol_MasterComboGroup.cbo_name);
            cmd.Parameters.AddWithValue("@cbo_style", bol_MasterComboGroup.cbo_style);
            cmd.Parameters.AddWithValue("@cbo_qty", bol_MasterComboGroup.cbo_qty);
            cmd.Parameters.AddWithValue("@cbo_branchid", bol_MasterComboGroup.cbo_branchid);
            cmd.Parameters.AddWithValue("@cbo_inactive", bol_MasterComboGroup.cbo_inactive);
            cmd.Parameters.AddWithValue("@cbo_createdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@cbo_createby", bol_MasterComboGroup.cbo_createby);
            cmd.Parameters.AddWithValue("@cbo_lastupdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@cbo_updateby", bol_MasterComboGroup.cbo_updateby);
            cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
            return SqlConjunction.GetSQLTransVoid(cmd);
        }

        public int Update_MasterComboGroup(BOL_Master_Combogroup bol_MasterComboGroup)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Update_mstr_combogroup";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@cbo_id", bol_MasterComboGroup.cbo_id );
            cmd.Parameters.AddWithValue("@cbo_number", bol_MasterComboGroup.cbo_number);
            cmd.Parameters.AddWithValue("@cbo_name", bol_MasterComboGroup.cbo_name);
            cmd.Parameters.AddWithValue("@cbo_style", bol_MasterComboGroup.cbo_style);
            cmd.Parameters.AddWithValue("@cbo_qty", bol_MasterComboGroup.cbo_qty);
            cmd.Parameters.AddWithValue("@cbo_branchid", bol_MasterComboGroup.cbo_branchid);
            cmd.Parameters.AddWithValue("@cbo_inactive", bol_MasterComboGroup.cbo_inactive);
            cmd.Parameters.AddWithValue("@cbo_createdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@cbo_createby", bol_MasterComboGroup.cbo_createby);
            cmd.Parameters.AddWithValue("@cbo_lastupdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@cbo_updateby", bol_MasterComboGroup.cbo_updateby);

            return SqlConjunction.GetSQLTransVoid(cmd);
        }
    }
}