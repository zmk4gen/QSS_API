using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace QSSAPI.DAL
{
    public class DAL_Dashboard
    {
        public DataTable SaleEnquiryAll(int branchid=0, string status = null)
        {
            if(status ==null)
            {
                 status = "Closed";
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SalesEnquiryAll_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@branchid", branchid);
            cmd.Parameters.AddWithValue("@status", status);
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable SaleEnquiryByDate(string startdate, string enddate,int branchid=0)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SaleEnquiry_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@startdate", Convert.ToDateTime(startdate));
            cmd.Parameters.AddWithValue("@enddate", Convert.ToDateTime(enddate));
            cmd.Parameters.AddWithValue("@branchid", branchid);
            cmd.Parameters.AddWithValue("@status", "closed");
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable SaleEnquiryByDateAndStatus(string startdate, string enddate, string status,int branchid=0)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SaleEnquiry_API";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@startdate", startdate);
            cmd.Parameters.AddWithValue("@enddate", enddate);
            cmd.Parameters.AddWithValue("@branchid", branchid);
            cmd.Parameters.AddWithValue("@status", status);
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable SaleSummaryReport_DeliveryAmt(string startdate, string enddate,  int branchid = 0, int pcfrom=0, int pcto=0,int saletypefrom=0,int saletypeto=0)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SaleSummaryReport_DeliveryAmt";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@startdate", startdate);
            cmd.Parameters.AddWithValue("@enddate", enddate);
            cmd.Parameters.AddWithValue("@branch", branchid);
            cmd.Parameters.AddWithValue("@rvc_pcFrom", pcfrom);
            cmd.Parameters.AddWithValue("@rvc_pcTo", pcto);
            cmd.Parameters.AddWithValue("@salestypeFrom", saletypefrom);
            cmd.Parameters.AddWithValue("@salestypeTo", saletypeto);
            return SqlConjunction.GetSQLDataTable(cmd);
        }
        public DataTable System_Sale_Report(string startdate, string enddate, int branchid = 0, int saletypefrom = 0, int saletypeto = 0, bool isMajoir = false, bool isFamilyGroup = true, bool reportGroup = false)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "System_Sale_Report_API";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fromdate",Convert.ToDateTime(startdate));
            cmd.Parameters.AddWithValue("@todate", Convert.ToDateTime(enddate));
            cmd.Parameters.AddWithValue("@branch", branchid);
            cmd.Parameters.AddWithValue("@fromsaletype", saletypefrom);
            cmd.Parameters.AddWithValue("@tosaletype", saletypeto);
            cmd.Parameters.AddWithValue("@isMajoir", isMajoir);
            cmd.Parameters.AddWithValue("@isFamilyGroup", isFamilyGroup);
            cmd.Parameters.AddWithValue("@reportGroup", reportGroup);
            return SqlConjunction.GetSQLDataTable(cmd);
        }
        /// <summary>
        /// Payment
        /// </summary>
        /// <param name="startdate"></param>
        /// <param name="enddate"></param>
        /// <param name="rvc"></param>
        /// <returns></returns>
        public DataTable OCENTPaymentReport(string startdate, string enddate, int rvc = 0)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "OCENTPaymentReport";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@startdate", startdate);
            cmd.Parameters.AddWithValue("@enddate", enddate);
            cmd.Parameters.AddWithValue("@branch", rvc);
        
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable PaymentAll_API(string startdate, string enddate)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "PaymentAll_API";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@startdate", startdate);
            cmd.Parameters.AddWithValue("@enddate", enddate);
   
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable PaymentByServingPeriod(string startdate, string enddate,string servingperiodfrom, string servingperiodto,int branchid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "PaymentByServingPeriod";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@startdate", startdate);
            cmd.Parameters.AddWithValue("@enddate", enddate);
            cmd.Parameters.AddWithValue("@servingperiod_from", servingperiodfrom);
            cmd.Parameters.AddWithValue("@servingperiod_to", servingperiodto);
            cmd.Parameters.AddWithValue("@branch_id", branchid);

            return SqlConjunction.GetSQLDataTable(cmd);
        }
        
    }
}