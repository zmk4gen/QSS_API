using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_TaxItem
    {
        public int taxitem_id { get; set; }
        public int taxitem_stockid { get; set; }
        public int taxitem_taxid { get; set; }
        public DateTime taxitem_createdate { get; set; }
        public string taxitem_createby { get; set; }
        public DateTime taxitme_lastupdate { get; set; }
        public string taxitem_updateby { get; set; }

    }
}