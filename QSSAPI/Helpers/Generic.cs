using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using QSSAPI.BOL;

namespace QSSAPI.Helpers
{
    public class Generic
    {
        public string gl_str_uid { get; set; }
        public string gl_str_checkno { get; set; }

        public int gl_int_Branch_ID { get; set; }
        public string gl_str_Branch_Code { get; set; }
        public string gl_str_Branch_Name { get; set; }
        public string gl_str_Branch_TypeDef { get; set; }
        public string gl_str_Branch_RoundingDue { get; set; }
        public string gl_str_Branch_SubGroup { get; set; }
        public string gl_str_Branch_PriceGroup { get; set; }

        public int gl_int_Branch_Group_ID { get; set; }
        public string gl_str_Branch_Group_Name { get; set; }

        public int gl_int_RVC_ID { get; set; }
        public string gl_str_RVC_Desc { get; set; }
        public string gl_str_RVC_TypeDef { get; set; }

        public DateTime gl_date_BusinessDate { get; set; }

        public string gl_str_SalesType_Code { get; set; }
        public string gl_str_SalesType_Desc { get; set; }
        public string gl_str_SalesTypeSuffix { get; set; }
        public string gl_str_SalesType_TypeDef { get; set; }
        public int gl_int_SalesType_TaxID { get; set; }
        public string gl_str_Price_Group { get; set; }

        public string gl_str_TransType_Code { get; set; }
        public string gl_str_TransType_Desc { get; set; }

        public decimal gl_dec_tax { get; set; }
        public decimal gl_dec_servicecharge { get; set; }
        public decimal gl_dec_roundingvariance { get; set; }

        public string gl_str_expeditionType { get; set; }

        public BOL_ServiceCharge gl_servicecharge { get; set; }
        public BOL_Discount gl_discount { get; set; }
    }
}