using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_Condiment
    {
        public int cond_number { get; set; }
        public string cond_name1 { get; set; }
        public string cond_name2 { get; set; }
        public string cond_name3 { get; set; }
        public int cond_qty { get; set; }
        public int cond_style { get; set; }
        public string cond_typedef { get; set; }
        public string cond_inactive { get; set; }
        public DateTime cond_createdate { get; set; }
        public string cond_createby { get; set; }
        public DateTime cond_lastupdate { get; set; }
        public string cond_updateby { get; set; }
    }
}