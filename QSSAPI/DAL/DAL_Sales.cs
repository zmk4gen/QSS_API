using QSSAPI.BOL;
using QSSAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace QSSAPI.DAL
{
    public class DAL_Sales
    {
        public int Insert_Sales(BOL_Sales bol_sa)
        {
            SqlCommand sqlCmd = new SqlCommand("sp_Insert_Sales_API_Ordering");
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.AddWithValue("@sa_ReceiptNo", bol_sa.sa_ReceiptNo);
            sqlCmd.Parameters.AddWithValue("@sa_Casher", bol_sa.sa_Casher);
            sqlCmd.Parameters.AddWithValue("@sa_SalesPerson", bol_sa.sa_SalesPerson);
            sqlCmd.Parameters.AddWithValue("@sa_SalesDate", bol_sa.sa_SalesDate);
            sqlCmd.Parameters.AddWithValue("@sa_memberno", bol_sa.sa_memberno);
            sqlCmd.Parameters.AddWithValue("@sa_Status", bol_sa.sa_Status);
            sqlCmd.Parameters.AddWithValue("@sa_CreateDate", bol_sa.sa_CreateDate);
            sqlCmd.Parameters.AddWithValue("@sa_Station", bol_sa.sa_Station);
            sqlCmd.Parameters.AddWithValue("@sa_CancelBy", bol_sa.sa_CancelBy);
            sqlCmd.Parameters.AddWithValue("@sa_CancelDT", bol_sa.sa_CancelDT);
            sqlCmd.Parameters.AddWithValue("@sa_CancelReason", bol_sa.sa_CancelReason);
            sqlCmd.Parameters.AddWithValue("@sa_uid", bol_sa.sa_uid);
            sqlCmd.Parameters.AddWithValue("@sa_CustCode", bol_sa.sa_CustCode);
            sqlCmd.Parameters.AddWithValue("@sa_DealerCode", bol_sa.sa_DealerCode);
            sqlCmd.Parameters.AddWithValue("@sa_Commission", bol_sa.sa_Commission);
            sqlCmd.Parameters.AddWithValue("@sa_BranchID", bol_sa.sa_BranchID);
            sqlCmd.Parameters.AddWithValue("@sa_LoyaltyTypeid", bol_sa.sa_LoyaltyTypeid);
            sqlCmd.Parameters.AddWithValue("@sa_LoyaltyCardno", bol_sa.sa_LoyaltyCardno);
            sqlCmd.Parameters.AddWithValue("@sa_HDSerialNo", bol_sa.sa_HDSerialNo);
            sqlCmd.Parameters.AddWithValue("@sa_roundingvariance", bol_sa.sa_roundingvariance);
            sqlCmd.Parameters.AddWithValue("@sa_InvoiceNo", bol_sa.sa_InvoiceNo);
            sqlCmd.Parameters.AddWithValue("@sa_pmuploaded", bol_sa.sa_pmuploaded);
            sqlCmd.Parameters.AddWithValue("@sa_pmvoiduploaded", bol_sa.sa_pmvoiduploaded);
            sqlCmd.Parameters.AddWithValue("@sa_custom1", bol_sa.sa_custom1);
            sqlCmd.Parameters.AddWithValue("@sa_custom2", bol_sa.sa_custom2);
            sqlCmd.Parameters.AddWithValue("@sa_custom3", bol_sa.sa_custom3);
            sqlCmd.Parameters.AddWithValue("@sa_SMPid", bol_sa.sa_SMPid);
            sqlCmd.Parameters.AddWithValue("@sa_SMPcode", bol_sa.sa_SMPcode);
            sqlCmd.Parameters.AddWithValue("@sa_SMPname", bol_sa.sa_SMPname);
            sqlCmd.Parameters.AddWithValue("@sa_businessdate", bol_sa.sa_businessdate);
            sqlCmd.Parameters.AddWithValue("@sa_SuspendDate", bol_sa.sa_SuspendDate);
            sqlCmd.Parameters.AddWithValue("@sa_SuspendDateDayEnd", bol_sa.sa_SuspendDateDayEnd);
            sqlCmd.Parameters.AddWithValue("@sa_servicecharge", bol_sa.sa_servicecharge);
            sqlCmd.Parameters.AddWithValue("@sa_tax", bol_sa.sa_tax);
            sqlCmd.Parameters.AddWithValue("@sa_clearbill", bol_sa.sa_clearbill);
            sqlCmd.Parameters.AddWithValue("@sa_cancelDTbusinessdate", bol_sa.sa_cancelDTbusinessdate);
            sqlCmd.Parameters.AddWithValue("@sa_SalesTime", bol_sa.sa_SalesTime);
            sqlCmd.Parameters.AddWithValue("@sa_custom4", bol_sa.sa_custom4);
            sqlCmd.Parameters.AddWithValue("@sa_kdsok", bol_sa.sa_kdsok);
            sqlCmd.Parameters.AddWithValue("@sa_kdstime", bol_sa.sa_kdstime);
            sqlCmd.Parameters.AddWithValue("@sa_kdsdt", bol_sa.sa_kdsdt);
            sqlCmd.Parameters.AddWithValue("@sa_transtype", bol_sa.sa_transtype);
            sqlCmd.Parameters.AddWithValue("@sa_salestype", bol_sa.sa_salestype);
            sqlCmd.Parameters.AddWithValue("@sa_SuspendBySalesPerson", bol_sa.sa_SuspendBySalesPerson);
            sqlCmd.Parameters.AddWithValue("@sa_split", bol_sa.sa_split);
            sqlCmd.Parameters.AddWithValue("@sa_splitfrom", bol_sa.sa_splitfrom);
            sqlCmd.Parameters.AddWithValue("@sa_splitseq", bol_sa.sa_splitseq);
            sqlCmd.Parameters.AddWithValue("@sa_splitseatno", bol_sa.sa_splitseatno);
            sqlCmd.Parameters.AddWithValue("@sa_BranchDesc", bol_sa.sa_BranchDesc);
            sqlCmd.Parameters.AddWithValue("@sa_BranchGrpID", bol_sa.sa_BranchGrpID);
            sqlCmd.Parameters.AddWithValue("@sa_BranchGrpDesc", bol_sa.sa_BranchGrpDesc);
            sqlCmd.Parameters.AddWithValue("@sa_RVCID", bol_sa.sa_RVCID);
            sqlCmd.Parameters.AddWithValue("@sa_RVCDesc", bol_sa.sa_RVCDesc);
            sqlCmd.Parameters.AddWithValue("@sa_PCID", bol_sa.sa_PCID);
            sqlCmd.Parameters.AddWithValue("@sa_checkno", bol_sa.sa_checkno);
            sqlCmd.Parameters.AddWithValue("@sa_iid", bol_sa.sa_iid);
            sqlCmd.Parameters.AddWithValue("@sa_printcopy", bol_sa.sa_printcopy);
            sqlCmd.Parameters.AddWithValue("@sa_SalesTypeSuffix", bol_sa.sa_SalesTypeSuffix);
            sqlCmd.Parameters.AddWithValue("@sa_datasource", bol_sa.sa_datasource);
            sqlCmd.Parameters.AddWithValue("@sa_printstatus", bol_sa.sa_printstatus);
            sqlCmd.Parameters.AddWithValue("@sa_printengine", bol_sa.sa_printengine);
            sqlCmd.Parameters.AddWithValue("@sa_printdt", bol_sa.sa_printdt);
            sqlCmd.Parameters.AddWithValue("@sa_billtoname", bol_sa.sa_billtoname);
            sqlCmd.Parameters.AddWithValue("@sa_billtoadd1", bol_sa.sa_billtoadd1);
            sqlCmd.Parameters.AddWithValue("@sa_billtoadd2", bol_sa.sa_billtoadd2);
            sqlCmd.Parameters.AddWithValue("@sa_billtoadd3", bol_sa.sa_billtoadd3);
            sqlCmd.Parameters.AddWithValue("@sa_billtoadd4", bol_sa.sa_billtoadd4);
            sqlCmd.Parameters.AddWithValue("@sa_billtoTelno", bol_sa.sa_billtoTelno);
            sqlCmd.Parameters.AddWithValue("@sa_billtoFaxno", bol_sa.sa_billtoFaxno);
            sqlCmd.Parameters.AddWithValue("@sa_closecheckrpt", bol_sa.sa_closecheckrpt);
            sqlCmd.Parameters.AddWithValue("@sa_shiftid", bol_sa.sa_shiftid);
            sqlCmd.Parameters.AddWithValue("@sa_shiftno", bol_sa.sa_shiftno);
            sqlCmd.Parameters.AddWithValue("@sa_shiftrefno", bol_sa.sa_shiftrefno);
            sqlCmd.Parameters.AddWithValue("@sa_sosorderstart", bol_sa.sa_sosorderstart);
            sqlCmd.Parameters.AddWithValue("@sa_sossubtotalstart", bol_sa.sa_sossubtotalstart);
            sqlCmd.Parameters.AddWithValue("@sa_soslastpaymentstart", bol_sa.sa_soslastpaymentstart);
            sqlCmd.Parameters.AddWithValue("@sa_sosclosedrawer", bol_sa.sa_sosclosedrawer);
            sqlCmd.Parameters.AddWithValue("@sa_salespersonname", bol_sa.sa_salespersonname);
            sqlCmd.Parameters.AddWithValue("@sa_mobile", bol_sa.sa_mobile);
            sqlCmd.Parameters.AddWithValue("@sa_syncdata", bol_sa.sa_syncdata);
            sqlCmd.Parameters.AddWithValue("@sa_syncvoiddata", bol_sa.sa_syncvoiddata);
            sqlCmd.Parameters.AddWithValue("@sa_expeditionType", bol_sa.sa_expeditionType);
            sqlCmd.Parameters.AddWithValue("@sa_token", bol_sa.sa_token);
            sqlCmd.Parameters.AddWithValue("@sa_code", bol_sa.sa_code);

            foreach (SqlParameter Parameter in sqlCmd.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }

            return SqlConjunction.GetSQLTransVoid(sqlCmd);
        }

        public DataTable Get_Sales(string sa_uid)
        {
            string str_cmd = "select ID, sa_uid, sa_status from Sales where sa_uid = '" + sa_uid + "';";
            SqlCommand sqlCmd = new SqlCommand(str_cmd);
            return SqlConjunction.GetSQLDataTable(sqlCmd);
        }

        public int Update_Sales_Status(string sa_uid, string status, string cancelreason)
        {
            string str_cmd = "Update Sales set sa_status = '" + status + "', sa_cancelDTbusinessdate = '" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "' ";
            str_cmd += "\r\n" + ", sa_CancelReason = '" + cancelreason + "' ";
            str_cmd += "\r\n" + "where sa_uid = '" + sa_uid + "';";
            SqlCommand sqlCmd = new SqlCommand(str_cmd);
            return SqlConjunction.GetSQLTransVoid(sqlCmd);
        }
    }
}