using QSSAPI.BOL;
using QSSAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QSSAPI.DAL
{
    public class DAL_Order_Raw_Data
    {
        public int Insert_Raw_Data(BOL_Order_Raw_Data obj_bol)
        {
            string str_cmd = "INSERT INTO [dbo].[Order_Raw_Data] ";
            str_cmd += "([ord_remoteid], [ord_RVCID], [ord_RVCName] ";
            str_cmd += ", [ord_BranchCode], [ord_BranchName], [ord_DeliveryTypeCode], [ord_DeliveryTypeDesc], [ord_uid] ";
            str_cmd += ", [ord_RawData], [ord_CreateDate], [ord_ImportToPOS_Done], [ord_ImportToPOS_DateTime]) output INSERTED.ord_ID VALUES ";
            str_cmd += "( @ord_remoteid, @ord_RVCID, @ord_RVCName";
            str_cmd += ", @ord_BranchCode, @ord_BranchName, @ord_DeliveryTypeCode, @ord_DeliveryTypeDesc, @ord_uid ";
            str_cmd += ", @ord_RawData, @ord_CreateDate, @ord_ImportToPOS_Done, @ord_ImportToPOS_DateTime)";

            SqlCommand sqlCmd = new SqlCommand(str_cmd);
            sqlCmd.Parameters.AddWithValue("@ord_remoteid", obj_bol.ord_remoteid);
            sqlCmd.Parameters.AddWithValue("@ord_RVCID", obj_bol.ord_RVCID);
            sqlCmd.Parameters.AddWithValue("@ord_RVCName", obj_bol.ord_RVCName);
            sqlCmd.Parameters.AddWithValue("@ord_BranchCode", obj_bol.ord_BranchCode);
            sqlCmd.Parameters.AddWithValue("@ord_BranchName", obj_bol.ord_BranchName);
            sqlCmd.Parameters.AddWithValue("@ord_DeliveryTypeCode", obj_bol.ord_DeliveryTypeCode);
            sqlCmd.Parameters.AddWithValue("@ord_DeliveryTypeDesc", obj_bol.ord_DeliveryTypeDesc);
            sqlCmd.Parameters.AddWithValue("@ord_uid", obj_bol.ord_uid);
            sqlCmd.Parameters.AddWithValue("@ord_RawData", obj_bol.ord_RawData);
            sqlCmd.Parameters.AddWithValue("@ord_CreateDate", DateTime.Now.ToString("yyyyMMdd HH:mm:ss"));
            sqlCmd.Parameters.AddWithValue("@ord_ImportToPOS_Done", 0);
            sqlCmd.Parameters.AddWithValue("@ord_ImportToPOS_DateTime", null);

            foreach (SqlParameter Parameter in sqlCmd.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }

            return SqlConjunction.GetSQLTransScalar(sqlCmd);
        }

        
    }
}