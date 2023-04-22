using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_StockPriceTable
    {
        public string pt_pgcode { get; set; }
        public decimal pt_minsp { get; set; }
        public decimal pt_sprice { get; set; }
        public int pt_stockid { get; set; }
        public string pt_uom { get; set; }
        public decimal pt_contain { get; set; }
        public string pt_att1 { get; set; }
        public string pt_att2 { get; set; }
        public int pt_branchid { get; set; }
        public DateTime pt_lastupdate { get; set; }
        public decimal pt_sprice1 { get; set; }
        public decimal pt_sprice2 { get; set; }
        public decimal pt_sprice3 { get; set; }
        public decimal pt_sprice4 { get; set; }
        public decimal pt_sprice5 { get; set; }
    }
}