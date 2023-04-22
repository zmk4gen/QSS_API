using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_StocksQty
    {
        public int sq_stockid { get; set; }
        public string sq_sn { get; set; }
        public string sq_uom { get; set; }
        public decimal sq_contain { get; set; }
        public string sq_locaiton { get; set; }
        public int sq_branchid { get; set; }
        public string sq_att1 { get; set; }
        public string sq_att2 { get; set; }
        public int sq_qyt { get; set; }
        public int sq_inactive { get; set; }
        public DateTime sq_lastupdate { get; set; }
        public int sq_minqty { get; set; }
        public int sq_serialnumber { get; set; }
        public int sq_voucher { get; set; }
        public int sq_prepaidtopup { get; set; }
        public int sq_servicetime { get; set; }
    }
}