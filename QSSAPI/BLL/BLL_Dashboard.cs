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
        public DataTable SaleEnquiryAll()
        {
            DAL_Dashboard dal_menuitem = new DAL_Dashboard();
            return dal_menuitem.SaleEnquiryAll();
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
    }
}