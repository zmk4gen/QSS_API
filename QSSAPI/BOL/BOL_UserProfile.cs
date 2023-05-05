using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_UserProfile
    {
        public int up_ID { get; set; }
        public string up_Name { get; set; }
        public string up_pumploaded { get; set; }
        public DateTime up_createdate { get; set; }
        public string up_createby { get; set; }
        public DateTime up_lastupdate { get; set; }
        public string up_updateby { get; set; }
        public int up_inactive { get; set; }
        public int up_localmaintain { get; set; }
        public string up_typedef { get; set; }

    }
}