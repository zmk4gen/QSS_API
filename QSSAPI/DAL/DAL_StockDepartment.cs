using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using QSSAPI.BOL;
using QSSAPI.BLL;
namespace QSSAPI.DAL


{
    public class DAL_StockDepartment
    {
        /// <summary>
        /// Majog Group
        /// </summary>
        /// <returns></returns>
        public DataTable BindMajorGroup()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindMajorGroup_API";
            cmd.CommandType = CommandType.StoredProcedure;
            return SqlConjunction.GetSQLDataTable(cmd);
        }
        public DataTable BindMajorGroupByCode(string code)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindMajorGroup_API";
            cmd.Parameters.AddWithValue("@code", code);
            cmd.CommandType = CommandType.StoredProcedure;

            return SqlConjunction.GetSQLDataTable(cmd);
        }
        public DataTable BindMajorGroupByName(string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindMajorGroup_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", name);
            return SqlConjunction.GetSQLDataTable(cmd);
        }
        public int Insert_MajorGroup(BOL_StockDepartment bol_stockdept)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "InsertStockDepartment_API";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@sd_Code", bol_stockdept.sd_Code);
            cmd.Parameters.AddWithValue("@sd_Name", bol_stockdept.sd_Name);
            cmd.Parameters.AddWithValue("@sd_Accno", bol_stockdept.sd_Accno);
            cmd.Parameters.AddWithValue("@sd_Inactive", bol_stockdept.sd_Inactive);
            cmd.Parameters.AddWithValue("@sd_LastUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@sd_UpdateBy", bol_stockdept.sd_UpdateBy);
            cmd.Parameters.AddWithValue("@sd_createdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@sd_createby", bol_stockdept.sd_createby);
            cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
            return SqlConjunction.GetSQLTransVoid(cmd);
        }
    }
}