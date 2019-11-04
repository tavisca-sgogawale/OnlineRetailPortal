using System;
using System.Collections.Generic;

namespace OnlineRetailPortal.Contracts.Errors
{
    public class CustomErrorResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public List<Tuple<int, string>> Info { get; set; }
    }
}
