using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_Location
    {
        public int loc_ID { get; set; }
        public string loc_Code { get; set; }
        public string loc_Name { get; set; }
        public int loc_BranchID { get; set; }
        public  string loc_createby { get; set; }
        public DateTime loc_createdate { get; set; }
        public string loc_updateby { get; set; }
        public DateTime loc_LastUpdate { get; set; }
        public int loc_inactive { get; set; }
    }
}