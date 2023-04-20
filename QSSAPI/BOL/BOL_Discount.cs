using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_Discount
    {
        public int disc_id { get; set; }
        public string disc_number { get; set; }
        public string disc_name1 { get; set; }
        public string disc_name2 { get; set; }
        public string disc_name3 { get; set; }
        public decimal disc_amount { get; set; }
        public string disc_itemdisc { get; set; }
        public string disc_typedef { get; set; }
        public string disc_privilege { get; set; }
        public bool is_item_discount { get; set; }
        public string str_disctype { get; set; }
        public bool is_autoservicecharge { get; set; }
        public bool is_percentage { get; set; }
    }
}