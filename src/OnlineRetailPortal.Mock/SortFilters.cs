using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineRetailPortal.Contracts;


namespace OnlineRetailPortal.Mock
{
    public static class SortFilters
    {
        public static List<Product> Apply(GetProductsEntity request, List<Product> productList)
        {
            var filterProducts = Filter(request, productList);
            return Sort(request, filterProducts);
        }

        public static List<Product> Filter(GetProductsEntity request, List<Product> productList)
        {
            if (request.Filters == null)
                return productList;
            return productList;
        }

        public static List<Product> Sort(GetProductsEntity request, List<Product> productList)
        {
            if (request.ProductSort == null)
                return productList;
            return request.ProductSort.Order == "Asc" ? productList.SortAsc(request.ProductSort.SortBy) : productList.SortDesc(request.ProductSort.SortBy);

        }
        public static List<Product> SortAsc(this List<Product> products, string SortBy)
        {
            return SortBy == "Price" ? products.OrderBy(x => x.Price.Money.Amount).ToList() : products.OrderBy(x => x.PostDateTime).ToList();
        }

        public static List<Product> SortDesc(this List<Product> products, string SortBy)
        {
            return SortBy == "Price" ? products.OrderByDescending(x => x.Price.Money.Amount).ToList() : products.OrderByDescending(x => x.PostDateTime).ToList();
        }
    }
}
