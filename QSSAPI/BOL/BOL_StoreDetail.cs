using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_StoreDetail
    {
        public int br_ID { get; set; }
        public string br_Code { get; set; }
        public string br_Name { get; set; }
        public string br_Address1 { get; set; }
        public string br_Address2 { get; set; }
        public string br_Address3 { get; set; }
        public string ms_Name { get; set; }
        public string brt_Description { get; set; }
        public DateTime br_LastUpdate { get; set; }
        public string br_updateby { get; set; }
    }
}