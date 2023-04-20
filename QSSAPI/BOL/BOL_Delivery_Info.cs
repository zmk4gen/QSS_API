using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_Delivery_Info
    {
        public int delinfo_ID { get; set; } //int identity(1, 1)
        public string delinfo_uid { get; set; }
        public string delinfo_email { get; set; } //varchar(200)
        public string delinfo_firstName { get; set; } //varchar(200)
        public string delinfo_lastName { get; set; } //varchar(200)
        public string delinfo_mobilePhone { get; set; } //varchar(200)
        public string delinfo_postcode { get; set; } //varchar(100)
        public string delinfo_city { get; set; } //varchar(100)
        public string delinfo_street { get; set; } //varchar(100)
        public string delinfo_number { get; set; } //varchar(100)
        public DateTime delinfo_expectedDeliveryTime { get; set; } //datetime
        public bool delinfo_expressDelivery { get; set; } //bit
        public Nullable<DateTime> delinfo_riderPickUpTime { get; set; } //datetime
    }
}