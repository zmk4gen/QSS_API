using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_ClockoutReason
    {
        public int cor_ID { get; set; }
        public string cor_Code { get; set; }
        public int cor_Name { get; set; }
        public DateTime cor_LastUpdate { get; set; }
        public string cor_updateby { get; set; }
        public string cor_createby { get; set; }
        public DateTime cor_createdate { get; set; }
        public int cor_inactive { get; set; }
        public int cor_workingtime { get; set; }
        public int cor_endshift { get; set; }
    }
}