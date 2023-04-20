using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_Order_Notification
    {
        public string ordernoti_ID { get; set; } //int
        public string ordernoti_OrderRawDataID { get; set; } //int
        public string ordernoti_uid { get; set; }
        public string ordernoti_DeliveryTypeCode { get; set; }
        public string ordernoti_CreateDT { get; set; } // datetime
        public string ordernoti_Done { get; set; } //bit default 0
        public string ordernoti_DoneDT { get; set; } //datetime
    }
}