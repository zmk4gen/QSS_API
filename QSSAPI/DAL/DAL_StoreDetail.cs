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
    public class DAL_StoreDetail
    {
        public DataTable BindStoreDetail()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Store_Detail_select";
            cmd.CommandType = CommandType.StoredProcedure;

            return SqlConjunction.GetSQLDataTable(cmd);
        }
        public DataTable BindStoreDetailByNumber(string number)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Store_Detail_select";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@br_Code", number);

            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindStoreDetailByName(string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindStoreDetail_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", name);
            return SqlConjunction.GetSQLDataTable(cmd);
        }
    }
}