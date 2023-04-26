using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_StoreGroup
    {
        public int brg_ID { get; set; }
        public string brg_Description { get; set; }
        public int brg_Inactive { get; set; }
        public string brg_CreateBy { get; set; }
        public DateTime brg_CreateDate { get; set; }
        public string brg_UpdateBy { get; set; }
        public DateTime brg_LastUpdate { get; set; }
        public int brg_number { get; set; }
    }
}