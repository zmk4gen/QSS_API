using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace QSSAPI.BOL
{
    public class BOL_Order_Raw_Data
    {

        public string ord_ID { get; set; } //int
        public string ord_remoteid { get; set; }
        public string ord_RVCID { get; set; } //int
        public string ord_RVCName { get; set; }
        public string ord_BranchCode { get; set; }
        public string ord_BranchName { get; set; }
        public string ord_DeliveryTypeCode { get; set; }
        public string ord_DeliveryTypeDesc { get; set; }
        public string ord_uid { get; set; }
        public string ord_RawData { get; set; }
        public string ord_CreateDate { get; set; } //datetime
        public string ord_ImportToPOS_Done { get; set; } //bit default 0
        public string ord_ImportToPOS_DateTime { get; set; } //datetime
    }
}