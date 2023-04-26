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
        public DataTable SaleEnquiryAll(string startdate=null,string enddate=null,string status=null)
        {
            if(startdate==null && enddate ==null && status ==null)
            {
                 startdate = System.DateTime.Now.ToString();
                 enddate = System.DateTime.Now.ToString();
                 status = "Closed";
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SaleEnquiry_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@startdate", startdate);
            cmd.Parameters.AddWithValue("@enddate", enddate);
            cmd.Parameters.AddWithValue("@status", status);
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable SaleEnquiryByDate(string startdate, string enddate)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SaleEnquiry_API";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@stockno", startdate);
            cmd.Parameters.AddWithValue("@enddate", enddate);
            return SqlConjunction.GetSQLDataTable(cmd);
        }

        public DataTable SaleEnquiryByDateAndStatus(string startdate, string enddate, string status)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SaleEnquiry_API";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@startdate", startdate);
            cmd.Parameters.AddWithValue("@enddate", enddate);
            cmd.Parameters.AddWithValue("@status", status);
            return SqlConjunction.GetSQLDataTable(cmd);
        }

    }
}