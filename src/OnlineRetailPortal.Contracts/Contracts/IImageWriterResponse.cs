using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Contracts.Contracts
{
    public interface IImageWriterResponse
    {
         bool Success { get;  set; }
         string Response { get; set; }

    }
}
