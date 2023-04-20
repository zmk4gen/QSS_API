using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_SalesDetails_Discount
    {
        public string sdd_id { get; set; } //int] IDENTITY(1,1) NOT NULL,
        public string sdd_uid { get; set; } //varchar](50) NULL,
        public string sdd_DisplayAftersdid { get; set; } //int] NULL,
        public int sdd_sdid { get; set; } //int] NULL,
        public string sdd_discidsequence { get; set; } //int] NULL,
        public int sdd_discid { get; set; } //int] NULL,
        public string sdd_discno { get; set; } //varchar](50) NULL,
        public string sdd_discname1 { get; set; } //nvarchar](255) NULL,
        public string sdd_disctype { get; set; } //varchar](20) NULL,
        public decimal sdd_discpercent { get; set; } //numeric](18, 6) NULL,
        public decimal sdd_discamount { get; set; } //numeric](18, 6) NULL,
        public string sdd_sn { get; set; } //varchar](50) NULL,
        public string sdd_stockid { get; set; } //int] NULL,
        public string sdd_uom { get; set; } //varchar](20) NULL,
        public decimal sdd_contain { get; set; } //decimal](18, 2) NULL,
        public string sdd_att1 { get; set; } //varchar](20) NULL,
        public string sdd_att2 { get; set; } //varchar](20) NULL,
        public decimal sdd_sprice { get; set; } //numeric](18, 4) NULL,
        public int sdd_qty { get; set; } //int] NULL,
        public string sdd_businessdate { get; set; } //datetime] NULL,
        public string sdd_createdate { get; set; } //datetime] NULL,
        public string sdd_createby { get; set; } //varchar](50) NULL,
        public string sdd_createbyname { get; set; } //varchar](100) NULL,
        public string sdd_discname2 { get; set; } //nvarchar](255) NULL,
        public string sdd_discname3 { get; set; } //nvarchar](255) NULL,
        public decimal sdd_AmtForCalcSVC { get; set; } //numeric](18, 4) NULL,
        public decimal sdd_AmtForCalcTax { get; set; } //numeric](18, 4) NULL,
        public string sdd_remarks { get; set; } //nvarchar](255) NULL,
        public string sdd_resume { get; set; } //varchar](50) NULL,
        public string sdd_SubtotalDiscByValue { get; set; } //varchar](1) NULL,
        public decimal sdd_SubtotalDiscValue { get; set; } //numeric](18, 4) NULL,
        public decimal discountamountwithtax { get; set; }
        public int sdd_branchid { get; set; } //int] NULL,
        public string sdd_iid { get; set; } //int] NULL,
        public string sdd_shiftid { get; set; } //int] NULL,
        public string sdd_shiftno { get; set; } //int] NULL,
        public string sdd_shiftrefno { get; set; } //varchar](50) NULL,
        public decimal sdd_Nett { get; set; } //numeric](18, 4) NULL,
        public decimal sdd_TotalAfterDiscount { get; set; } //numeric](18, 4) NULL,
        public string sdd_syncdata { get; set; } //nvarchar](2) NULL,
        public string sdd_syncvoiddata { get; set; } //nvarchar](2) NULL
    }
}