﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using QSSAPI.BOL;
using DAL;


namespace QSSAPI.DAL
{
    public class DAL_StoreGroup
    {
        public DataTable BindStoreGroup()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindStoreGroup_API";
            cmd.CommandType = CommandType.StoredProcedure;
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindStoreGroupByNumber(string number)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindStoreGroup_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@brg_ID", number);

            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindStoreGroupByName(string desc)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindStoreGroup_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@desc", desc);

            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public int Insert_StoreGroup(BOL_StoreGroup bol_StoreGroup)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "InsertStoreGroup";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@brg_ID", bol_StoreGroup.brg_ID);
            cmd.Parameters.AddWithValue("@brg_Description", bol_StoreGroup.brg_Description);
            cmd.Parameters.AddWithValue("@brg_Inactive", bol_StoreGroup.brg_Inactive);
            cmd.Parameters.AddWithValue("@brg_CreateBy", bol_StoreGroup.brg_CreateBy);
            cmd.Parameters.AddWithValue("@brg_CreateDate",DateTime.Now);
            cmd.Parameters.AddWithValue("@brg_UpdateBy", bol_StoreGroup.brg_UpdateBy);
            cmd.Parameters.AddWithValue("@brg_LastUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@brg_number", bol_StoreGroup.brg_number);
            
            return SqlConjunction.GetSQLTransVoid(cmd);
        }

    }
}