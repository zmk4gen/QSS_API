using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_Currency
    {
        public int curr_code { get; set; }
	    public string curr_name { get; set; }
        public string curr_symbol { get; set; }
        public bool curr_inactive { get; set; }
        public string curr_createby { get; set; }
        public DateTime curr_createdate { get; set; }
        public string curr_updateby { get; set; }
        public DateTime curr_lastupdate { get; set; }
    }
}