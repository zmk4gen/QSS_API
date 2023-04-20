using QSSAPI.BOL;
using QSSAPI.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QSSAPI.DAL
{
    public class DAL_Delivery_Info
    {
        public int Insert_Delivery_Info(BOL_Delivery_Info bol_del)
        {
            string str_cmd = "INSERT INTO [dbo].[Delivery_Info] ";
            str_cmd += "\r\n" + "( [delinfo_uid], [delinfo_email], [delinfo_firstName], [delinfo_lastName], [delinfo_mobilePhone] ";
            str_cmd += "\r\n" + ", [delinfo_postcode], [delinfo_city], [delinfo_street], [delinfo_number] ";
            str_cmd += "\r\n" + ", [delinfo_expectedDeliveryTime], [delinfo_expressDelivery], [delinfo_riderPickUpTime]) ";
            str_cmd += "\r\n" + "VALUES ( @delinfo_uid, @delinfo_email, @delinfo_firstName, @delinfo_lastName, @delinfo_mobilePhone ";
            str_cmd += "\r\n" + ", @delinfo_postcode, @delinfo_city, @delinfo_street, @delinfo_number ";
            str_cmd += "\r\n" + ", @delinfo_expectedDeliveryTime, @delinfo_expressDelivery, @delinfo_riderPickUpTime)";

            SqlCommand sqlCmd = new SqlCommand(str_cmd);
            sqlCmd.Parameters.AddWithValue("@delinfo_uid", bol_del.delinfo_uid);
            sqlCmd.Parameters.AddWithValue("@delinfo_email", bol_del.delinfo_email);
            sqlCmd.Parameters.AddWithValue("@delinfo_firstName", bol_del.delinfo_firstName);
            sqlCmd.Parameters.AddWithValue("@delinfo_lastName", bol_del.delinfo_lastName);
            sqlCmd.Parameters.AddWithValue("@delinfo_mobilePhone", bol_del.delinfo_mobilePhone);
            sqlCmd.Parameters.AddWithValue("@delinfo_postcode", bol_del.delinfo_postcode);
            sqlCmd.Parameters.AddWithValue("@delinfo_city", bol_del.delinfo_city);
            sqlCmd.Parameters.AddWithValue("@delinfo_street", bol_del.delinfo_street);
            sqlCmd.Parameters.AddWithValue("@delinfo_number", bol_del.delinfo_number);
            sqlCmd.Parameters.AddWithValue("@delinfo_expectedDeliveryTime", bol_del.delinfo_expectedDeliveryTime);
            sqlCmd.Parameters.AddWithValue("@delinfo_expressDelivery", bol_del.delinfo_expressDelivery);
            sqlCmd.Parameters.AddWithValue("@delinfo_riderPickUpTime", bol_del.delinfo_riderPickUpTime);

            return SqlConjunction.GetSQLTransVoid(sqlCmd);
        }
    }
}