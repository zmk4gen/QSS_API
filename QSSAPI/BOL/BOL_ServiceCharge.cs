using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_ServiceCharge
    {
        public int sc_id { get; set; } = default(int);
        public string sc_number { get; set; } = default(string);
        public string sc_desc { get; set; } = default(string);
        public string sc_type { get; set; } = default(string);
        public string sc_accountcode { get; set; } = default(string);
        public decimal sc_percentage { get; set; } = default(decimal);
        public decimal sc_startamount { get; set; } = default(decimal);
        public string sc_createdate { get; set; } = default(string);
        public string sc_createby { get; set; } = default(string);
        public string sc_lastupdate { get; set; } = default(string);
        public string sc_updateby { get; set; } = default(string);
        public bool sc_inactive { get; set; } = default(bool);
        public string sc_typedef { get; set; } = default(string);
    }
}