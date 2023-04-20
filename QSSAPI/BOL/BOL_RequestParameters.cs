using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_RequestParameters
    {
        public string reqprm_deliverychannel_code { get; set; }
        public string reqprm_Status { get; set; }
        public string reqprm_Message { get; set; }
        public int reqprm_RVCID { get; set; }
        public string reqprm_RVCName { get; set; }
        public string reqprm_BranchCode { get; set; }
        public string reqprm_BranchName { get; set; }
        public string remoteOrderId { get; set; }
        //public string reqprm_AuthKey_Name { get; set; }
        //public string reqprm_AuthKey_Pass { get; set; }
        //public string reqprm_HQ_DBConnection { get; set; }
    }
}