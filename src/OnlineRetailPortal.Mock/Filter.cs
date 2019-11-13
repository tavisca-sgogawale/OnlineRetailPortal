using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Mock
{
    public static class Filter
    {
        public static List<Product> ApplyFilter(this List<Product> productList, List<Contracts.Filter> filters)
        {
            if (filters == null)
                return productList;
            return productList;
        }
    }
}
