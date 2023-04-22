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
    public class DAL_StoreSubGroup
    {
        public DataTable BindStoreSubGroup()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Store_Sub_Group_Select";
            cmd.CommandType = CommandType.StoredProcedure;
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindStoreSubGroupByNumber(string number)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Store_Sub_Group_Select";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@bsg_code", number);

            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindStoreSubGroupByDesc(string desc)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Store_Sub_Group_Select";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@desc", desc);
            return SqlConjunction.GetSQLDataTable(cmd);
        }
    }
}