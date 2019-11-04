using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Web
{
    public class PagingInfo
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public SortBy SortBy { get; set; }
    }
}
