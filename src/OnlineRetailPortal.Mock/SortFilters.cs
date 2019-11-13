using System;
using System.Collections.Generic;
using System.Text;
using OnlineRetailPortal.Contracts;


namespace OnlineRetailPortal.Mock
{
    public  class  SortFilters
    {
        public List<Product> Apply(GetProductsEntity request, List<Product> productList)
        {
            var filterProducts = Filter(request, productList);
            return Sort(request,filterProducts);
        }

        public static List<Product> Sort(GetProductsEntity request,List<Product> products)
        {
            if (request.Filters == null)
                return products;
            return products;
        }

        public static List<Product> Filter(GetProductsEntity request, List<Product> productList)
        {
            if (request.Filters == null)
                return productList;
            return productList;
        }
    }
}
