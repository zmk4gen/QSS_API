using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_Tax_and_SVC_Amount
    {
        public decimal sd_TaxAmount { get; set; }
        public decimal sd_TaxAmountActual { get; set; }
        public decimal sd_AddOnTaxAmountActual { get; set; }
        public decimal sd_ItemAddOnTaxAmountActual { get; set; }
        public decimal sd_InclusiveTaxAmountActual { get; set; }
        public decimal sd_ItemInclusiveTaxAmountActual { get; set; }
        public decimal sd_ItemTaxAmount { get; set; }
        public decimal sd_ItemTaxAmountActual { get; set; }

        public decimal discount_amount_without_Tax { get; set; }


        public decimal disc_tax { get; set; }

        public decimal sd_SVCAddOnTaxAmountActual { get; set; }

        public decimal sd_SVCInclusiveTaxAmountActual { get; set; }

        public decimal sd_svcamount { get; set; }

        public decimal sd_svcamountactual { get; set; }

        public decimal sd_SVCTaxAmount { get; set; }

        public decimal sd_SVCTaxAmountActual { get; set; }


    }
}