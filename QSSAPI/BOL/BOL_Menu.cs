using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_stock
    {
        public int stock_id { get; set; }

        public string stock_no { get; set; }
            
        public string stock_description { get; set; }

        public string stock_description2 { get; set; }

        public string stock_description3 { get; set; }

        public string st_barcode { get; set; }

        public int st_DeptID { get; set; }

        public int st_StockGroupID { get; set; }

        public int st_StockType { get; set; }

        public string st_ArticleNo { get; set; }

        public int st_SuppID { get; set; }

        public int st_OpenPrice { get; set; }

        public string st_Obsolete { get; set; }
        public string st_allowNeg { get; set; }

        public string st_CP { get; set; }

        public string st_Remarks { get; set; }

        public string st_CreateBy { get; set; }

        public DateTime st_CreateDate { get; set; }

        public string st_UpdateBy { get; set; }

        public DateTime st_LastUpdate { get; set; }

        public string st_Discount { get; set; }

        public string st_forSO { get; set; }

        public int st_taxid { get; set; }
        public int st_nluid { get; set; }
        public int st_sluid { get; set; }
        public string st_combo { get; set; }
        public string st_combopattern { get; set; }
        public string st_requireremarks { get; set; }
        public string st_discitemize { get; set; }
        public int st_ServiceChargeID { get; set; }
        public DateTime st_effectivefrom { get; set; }

        public DateTime st_effectiveto { get; set; }

        public bool st_effectivedate { get; set; }
        public int st_keyboardnumber { get; set; }
        public bool st_printOnGuestCheck { get; set; }
        public bool st_PrintOnReceipt { get; set; }
        public string st_menuprivilege { get; set; }
        public string st_kdstimer { get; set; }
        public string st_pcscount { get; set; }
        public string st_count { get; set; }
        public decimal st_cost { get; set; }
        public string st_fireonthefly { get; set; }
        public string st_kdsgroup { get; set; }
        /// <summary>
        /// Stock Price
        /// </summary>
        public int pt_sprice { get; set; }
        /// <summary>
        /// Branch
        /// </summary>
        public int branchid { get; set; }
        public int location_id { get; set; }
        public string price_group { get; set; }
        /// <summary>
        /// Stock Qty
        /// </summary>
        public int stock_qty { get; set; }


    }
}