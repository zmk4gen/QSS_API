using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_TenderMedia
    {
        public int tm_code { get; set; }
	    public string tm_description { get; set; }
        public string tm_name2 { get; set; }
        public string tm_name3 { get; set; }
        public int tm_group { get; set; }
        public int tm_keyboard { get; set; }
        public decimal tm_halo { get; set; }
        public string tm_acccode { get; set; }
        public string tm_preamable { get; set; }
        public string tm_type { get; set; }
        public int tm_chargetips { get; set; }
        public int tm_interface { get; set; }
        public int tm_trailer1 { get; set; }
        public int tm_trailer2 { get; set; }
        public int tm_trailer3 { get; set; }
        public int tm_nluid { get; set; }
        public int tm_sluid { get; set; }
        public string tm_nlunumber { get; set; }
        public bool tm_printguestcheck { get; set; }
        public bool tm_printreceipt { get; set; }
        public bool tm_inactive { get; set; }
        public DateTime tm_createdate { get; set; }
        public string tm_createby { get; set; }
        public DateTime tm_lastupdate { get; set; }
        public string tm_updateby { get; set; }
        public string tm_typedef { get; set; }
        public string tm_privilege { get; set; }
        public int tm_cash { get; set; }

        public int tm_currency { get; set; }
    }
}