using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Core.Models
{
    public class Page
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PageSortBy SortBy { get; set; }

    }
}
