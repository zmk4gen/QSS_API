using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_UserInfo
    {
        public int ui_id { get; set; }
        public string ui_code { get; set; }
        public string ui_name { get; set; }
        public string ui_password { get; set; }
        public int ui_profileID { get; set; }
        public int ui_countryID { get; set; }
        public string ui_logon { get; set; }
        public int ui_branchID { get; set; }
        public DateTime ui_ValidFrom { get; set; }
        public DateTime ui_ValidTo { get; set; }
        public int ui_DocNo { get; set; }
        public int ui_onbehalf { get; set; }
        public string ui_createby { get; set; }
        public DateTime ui_createdate { get; set; }
        public string ui_updateby { get; set; }
        public DateTime ui_lastupdate { get; set; }
        public int ui_inactive { get; set; }
        public string ui_telno { get; set; }
        public string ui_email { get; set; }
        public string ui_address1 { get; set; }
        public string ui_address2 { get; set; }
        public string ui_address3 { get; set; }
        public string ui_password2 { get; set; }
        public int ui_ishq { get; set; }
        public string ui_fingerprint { get; set; }
        public string ui_lastfield { get; set; }
        public int ui_OCLimitDaily { get; set; }
        public int ui_OCLimitMonthly { get; set; }
        public int ui_ENTLimitDaily { get; set; }
        public int ui_ENTLimitMonthly { get; set; }
        public string ui_UserDepartment { get; set; }
        public int ui_globaluser { get; set; }
        public int ui_OCAmtDaily { get; set; }
        public int ui_OCAmt1 { get; set; }
        public int ui_OCAmt2 { get; set; }
        public int ui_OCAmt3 { get; set; }
        public int ui_OCAmt4 { get; set; }
        public int ui_OCAmt5 { get; set; }
        public int ui_OCAmt6 { get; set; }
        public int ui_OCAmt7 { get; set; }
        public int ui_OCAmt8 { get; set; }
        public int ui_OCAmt9 { get; set; }
        public int ui_OCAmt10 { get; set; }
        public int ui_OCAmt11 { get; set; }
        public int ui_OCAmt12 { get; set; }
        public int ui_ENTAmtDaily { get; set; }
        public int ui_ENTAmt1 { get; set; }
        public int ui_ENTAmt2 { get; set; }
        public int ui_ENTAmt3 { get; set; }
        public int ui_ENTAmt4 { get; set; }
        public int ui_ENTAmt5 { get; set; }
        public int ui_ENTAmt6 { get; set; }
        public int ui_ENTAmt7 { get; set; }
        public int ui_ENTAmt8 { get; set; }
        public int ui_ENTAmt9 { get; set; }
        public int ui_ENTAmt10 { get; set; }
        public int ui_ENTAmt11 { get; set; }
        public int ui_ENTAmt12 { get; set; }
        public DateTime ui_synOCENTlastupdate { get; set; }
        public int ui_training { get; set; }
        public string ui_uploadPWD { get; set; }
    }
}