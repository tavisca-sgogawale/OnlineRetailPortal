using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Contracts.Contracts
{
    public interface IImageWriterResponse
    {
        public bool Success { get;  set; }
        public string Response { get; set; }

    }
}
