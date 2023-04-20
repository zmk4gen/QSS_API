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
    public class DAL_TenderMedia
    {
        public DataTable BindTenderMedia()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindTenderMedia_API";
            cmd.CommandType = CommandType.StoredProcedure;

            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindTenderMediaByNumber(string number)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindTenderMedia_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tm_code", number);

            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable BindTenderMediaByName(string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BindTenderMedia_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@desc", name);

            return SqlConjunction.GetSQLDataTable(cmd);
        }
        public int Insert_TenderMeida(BOL_TenderMedia bol_TenderMedia)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "InsertTenderMedia";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@tm_code", bol_TenderMedia.tm_code);
            cmd.Parameters.AddWithValue("@tm_description", bol_TenderMedia.tm_description);
            cmd.Parameters.AddWithValue("@tm_name2", bol_TenderMedia.tm_name2);
            cmd.Parameters.AddWithValue("@tm_name3", bol_TenderMedia.tm_name3);
            cmd.Parameters.AddWithValue("@tm_group", bol_TenderMedia.tm_group);
            cmd.Parameters.AddWithValue("@tm_keyboard", bol_TenderMedia.tm_keyboard);
            cmd.Parameters.AddWithValue("@tm_halo", bol_TenderMedia.tm_halo);
            cmd.Parameters.AddWithValue("@tm_acccode", bol_TenderMedia.tm_acccode);
            cmd.Parameters.AddWithValue("@tm_preamable", bol_TenderMedia.tm_preamable);
            cmd.Parameters.AddWithValue("@tm_type", bol_TenderMedia.tm_type);
            cmd.Parameters.AddWithValue("@tm_chargetips", bol_TenderMedia.tm_chargetips);
            cmd.Parameters.AddWithValue("@tm_interface", bol_TenderMedia.tm_interface);
            cmd.Parameters.AddWithValue("@tm_trailer1", bol_TenderMedia.tm_trailer1);
            cmd.Parameters.AddWithValue("@tm_trailer2", bol_TenderMedia.tm_trailer2);
            cmd.Parameters.AddWithValue("@tm_trailer3", bol_TenderMedia.tm_trailer3);
            cmd.Parameters.AddWithValue("@tm_nluid", bol_TenderMedia.tm_nluid);
            cmd.Parameters.AddWithValue("@tm_sluid", bol_TenderMedia.tm_sluid);
            cmd.Parameters.AddWithValue("@tm_nlunumber", bol_TenderMedia.tm_nlunumber);
            cmd.Parameters.AddWithValue("@tm_printguestcheck", bol_TenderMedia.tm_printguestcheck);
            cmd.Parameters.AddWithValue("@tm_printreceipt", bol_TenderMedia.tm_printreceipt);
            cmd.Parameters.AddWithValue("@tm_inactive", bol_TenderMedia.tm_inactive);
            cmd.Parameters.AddWithValue("@tm_createdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@tm_createby", bol_TenderMedia.tm_createby);
            cmd.Parameters.AddWithValue("@tm_lastupdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@tm_updateby", bol_TenderMedia.tm_updateby);
            cmd.Parameters.AddWithValue("@tm_typedef", bol_TenderMedia.tm_typedef);
            cmd.Parameters.AddWithValue("@tm_privilege", bol_TenderMedia.tm_privilege);
            cmd.Parameters.AddWithValue("@tm_cash", bol_TenderMedia.tm_cash);
            cmd.Parameters.AddWithValue("@tm_currency", bol_TenderMedia.tm_currency);

            return SqlConjunction.GetSQLTransVoid(cmd);
        }
    }
}