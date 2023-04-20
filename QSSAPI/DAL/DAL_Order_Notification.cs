using QSSAPI.BOL;
using QSSAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QSSAPI.DAL
{
    public class DAL_Order_Notification
    {
        public int Insert_Order_Notification(BOL_Order_Notification obj_bol)
        {
            string str_cmd = "INSERT INTO [dbo].[Order_Notification] ";
            str_cmd += "([ordernoti_OrderRawDataID], [ordernoti_uid], [ordernoti_DeliveryTypeCode] ";
            str_cmd += ", [ordernoti_CreateDT], [ordernoti_Done], [ordernoti_DoneDT]) VALUES ";
            str_cmd += "(@ordernoti_OrderRawDataID, @ordernoti_uid, @ordernoti_DeliveryTypeCode ";
            str_cmd += ", @ordernoti_CreateDT, @ordernoti_Done, @ordernoti_DoneDT)";

            SqlCommand sqlCmd = new SqlCommand(str_cmd);
            sqlCmd.Parameters.AddWithValue("@ordernoti_OrderRawDataID", obj_bol.ordernoti_OrderRawDataID);
            sqlCmd.Parameters.AddWithValue("@ordernoti_uid", obj_bol.ordernoti_uid);
            sqlCmd.Parameters.AddWithValue("@ordernoti_DeliveryTypeCode", obj_bol.ordernoti_DeliveryTypeCode);
            sqlCmd.Parameters.AddWithValue("@ordernoti_CreateDT", DateTime.Now.ToString("yyyyMMdd HH:mm:ss"));
            sqlCmd.Parameters.AddWithValue("@ordernoti_Done", 0);
            sqlCmd.Parameters.AddWithValue("@ordernoti_DoneDT", null);

            foreach (SqlParameter Parameter in sqlCmd.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }

            return SqlConjunction.GetSQLTransVoid(sqlCmd);
        }
    }
}