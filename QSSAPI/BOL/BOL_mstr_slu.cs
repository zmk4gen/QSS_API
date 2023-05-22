﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_mstr_slu
    {
        public int slu_id { get; set; }
        public int slu_number { get; set; }
	    public string slu_name { get; set; }
        public int slu_style { get; set; }
        public int slu_branchid { get; set; }
        public bool slu_inactive { get; set; }
        public DateTime slu_createdate { get; set; }
        public string slu_createby { get; set; }
        public DateTime slu_lastupdate { get; set; }
        public string slu_updateby { get; set; }
    }
}