using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_StockGroup
    {
        public string sg_Code { get; set; }
	    public string sg_Name { get; set; }
	    public string sg_Accno { get; set; }
        public bool sg_Inactive { get; set; }
        public DateTime sg_LastUpdate { get; set; }
	    public string sg_UpdateBy { get; set; }
        public DateTime sg_createdate { get; set; }
        public string sg_createby { get; set; }
    }
}