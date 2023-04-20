using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_Tax
    {
        public int tax_id { get; set; }
        public string tax_number { get; set; }
        public string tax_desc { get; set; }
        public string tax_type { get; set; }
        public string tax_accountcode { get; set; }
        public decimal tax_percentage { get; set; }
        public decimal tax_startamount { get; set; }
        public DateTime tax_createdate { get; set; }
        public string tax_createby { get; set; }
        public DateTime tax_lastupdate { get; set; }
        public string tax_updateby { get; set; }
        public bool tax_inactive { get; set; }
        public string Tax_code { get; set; }
    }
}