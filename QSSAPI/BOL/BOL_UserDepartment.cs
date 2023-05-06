using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_UserDepartment
    {
        public int ud_ID { get; set; }
        public string ud_Code { get; set; }
        public string ud_Name { get; set; }
        public int ud_inactive { get; set; }
        public DateTime ud_lastupdate { get; set; }
        public string ud_updateby { get; set; }
        public DateTime ud_createdate { get; set; }
        public string ud_createby { get; set; }
    }
}