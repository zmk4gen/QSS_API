using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using QSSAPI.DAL;

namespace QSSAPI.BLL
{
    public class BLL_Dashboard
    {
        public DataTable SaleEnquiryAll(int branchid,string status)
        {
            DAL_Dashboard dal_menuitem = new DAL_Dashboard();
            return dal_menuitem.SaleEnquiryAll(branchid,status);
        }
        public DataTable SaleEnquiryByDate(string startdate,string enddate)
        {
            DAL_Dashboard dal_menuitem = new DAL_Dashboard();
            return dal_menuitem.SaleEnquiryByDate(startdate,enddate);
        }
        public DataTable SaleEnquiryByDateAndStatus(string startdate, string enddate,string status)
        {
            DAL_Dashboard dal_menuItem = new DAL_Dashboard();
            return dal_menuItem.SaleEnquiryByDateAndStatus(startdate, enddate, status);
        }

        public DataTable SaleSummaryReport_DeliveryAmt(string startdate, string enddate, int branchid = 0, int pcfrom = 0, int pcto = 0, int saletypefrom = 0, int saletypeto = 0)
        {
            DAL_Dashboard dal_menuItem = new DAL_Dashboard();
            return dal_menuItem.SaleSummaryReport_DeliveryAmt(startdate, enddate, branchid, pcfrom, pcto, saletypefrom, saletypeto);
        }
        public DataTable System_Sale_Report(string startdate, string enddate, int branchid = 0, int saletypefrom = 0, int saletypeto = 0, bool isMajoir = false, bool isFamilyGroup = true, bool reportGroup = false)
        {
            DAL_Dashboard dal_menuItem = new DAL_Dashboard();
            return dal_menuItem.System_Sale_Report(startdate, enddate, branchid, saletypefrom, saletypeto, isMajoir, isFamilyGroup, reportGroup);
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
            DAL_Dashboard dal_menuItem = new DAL_Dashboard();
            return dal_menuItem.OCENTPaymentReport(startdate, enddate, rvc);
        }
        public DataTable PaymentAll_API(string startdate, string enddate)
        {
            DAL_Dashboard dal_menuItem = new DAL_Dashboard();
            return dal_menuItem.PaymentAll_API(startdate, enddate);
        }
        public DataTable PaymentByServingPeriod(string startdate, string enddate, string servingperiodfrom, string servingperiodto, int branchid)
        {
            DAL_Dashboard dal_menuItem = new DAL_Dashboard();
            return dal_menuItem.PaymentByServingPeriod(startdate, enddate, servingperiodfrom, servingperiodto, branchid);
        }
    }
}