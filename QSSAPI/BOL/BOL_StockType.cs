using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_StockType
    {
        public string stype_Code { get; set; }
	    public string stype_Name { get; set; }
        public string stype_Accno { get; set; }
        public bool stype_Inactive { get; set; }
        public DateTime stype_LastUpdate { get; set; }
        public string stype_UpdateBy { get; set; }
        public DateTime stype_createdate { get; set; }
        public string stype_createby { get; set; }
    }
}