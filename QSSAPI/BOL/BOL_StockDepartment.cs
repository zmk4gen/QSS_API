using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_StockDepartment
    {
        public string sd_Code { get; set; }
	    public string sd_Name { get; set; }
	    public string sd_Accno { get; set; }
	    public bool sd_Inactive { get; set; }
        public DateTime sd_LastUpdate { get; set; }
	    public string sd_UpdateBy { get; set; }
	    public DateTime sd_createdate { get; set; }
        public string sd_createby { get; set; }
    }
}