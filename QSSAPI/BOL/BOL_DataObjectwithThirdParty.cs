using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_ResponseToThirdParty
    {
        public BOL_RemoteOrder remoteResponse { get; set; }
        public string reason { get; set; }
        public string message { get; set; }
    }

    public class BOL_RemoteOrder
    {
        public string remoteOrderId { get; set; }
    }

    public class BOL_Order_Update
    {
        public string status { get; set; }
        public string message { get; set; }
    }
}