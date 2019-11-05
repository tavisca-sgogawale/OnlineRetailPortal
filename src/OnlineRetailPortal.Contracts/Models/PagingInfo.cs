using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Contracts
{
    public class PagingInfo
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public SortBy SortBy { get; set; }
        public int TotalPages { get; set; }
    }
}
