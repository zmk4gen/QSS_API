using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_TenderMediaSLU
    {
        public int tmslu_number { get; set; }
	    public string tmslu_name { get; set; }
        public int tmslu_branchid { get; set; }
        public bool tmslu_inactive { get; set; }
        public DateTime tmslu_createdate { get; set; }
        public string tmslu_createby { get; set; }
        public DateTime tmslu_lastupdate { get; set; }
        public string tmslu_updateby { get; set; }
    }
}