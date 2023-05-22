using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_Master_Combogroup
    {
        public int cbo_id { get; set; }
        public int cbo_number { get; set; }
	    public string cbo_name { get; set; }
        public int cbo_style { get; set; }
        public int cbo_qty { get; set; }
        public int cbo_branchid { get; set; }
        public bool cbo_inactive { get; set; }
        public DateTime cbo_createdate { get; set; }
        public string cbo_createby { get; set; }
        public DateTime cbo_lastupdate { get; set; }
        public string cbo_updateby { get; set; }
    }
}