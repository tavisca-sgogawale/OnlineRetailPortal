using System;
using System.Collections.Generic;
using System.Net;

namespace OnlineRetailPortal.Contracts
{
    public class CustomErrorResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public List<ErrorInfo> Info { get; set; }
    }
}
