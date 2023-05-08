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
    public class DAL_Currency
    {
        public DataTable BindCurrency()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindCurrency_API";
            cmd.CommandType = CommandType.StoredProcedure;
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindCurrencyByNumber(string number)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindCurrency_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@curr_code", number);

            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindCurrencyByName(string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindCurrency_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", name);
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public int Insert_Currency(BOL_Currency bol_Currency)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "InsertCurrency";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@curr_code", bol_Currency.curr_code);
            cmd.Parameters.AddWithValue("@curr_name", bol_Currency.curr_name);
            cmd.Parameters.AddWithValue("@curr_symbol", bol_Currency.curr_symbol);
            cmd.Parameters.AddWithValue("@curr_inactive", bol_Currency.curr_inactive);
            cmd.Parameters.AddWithValue("@curr_createby", bol_Currency.curr_createby);
            cmd.Parameters.AddWithValue("@curr_createdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@curr_updateby", bol_Currency.curr_updateby);
            cmd.Parameters.AddWithValue("@curr_lastupdate", DateTime.Now);
            cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
            return SqlConjunction.GetSQLTransVoid(cmd);
        }
    }
}