using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Contracts.Contracts
{
    public interface ICategoryResponse
    {
        int Status { get; set; }
        string Message { get; set; }
    }
}
