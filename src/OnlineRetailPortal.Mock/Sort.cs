using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRetailPortal.Mock
{
    public static class Sort
    {
        public static List<Product> ApplySort(this List<Product> productList ,Contracts.ProductSort productSort)
        {
            if (productSort == null)
                return productList;
            return productSort.Order == "Asc" ? productList.SortAsc(productSort.SortBy) : productList.SortDesc(productSort.SortBy);

        }
        public static List<Product> SortAsc(this List<Product> products, string sortBy)
        {
            return sortBy == "Price" ? products.OrderBy(x => x.Price.Money.Amount).ToList() : products.OrderBy(x => x.PostDateTime).ToList();
        }

        public static List<Product> SortDesc(this List<Product> products, string sortBy)
        {
            return sortBy == "Price" ? products.OrderByDescending(x => x.Price.Money.Amount).ToList() : products.OrderByDescending(x => x.PostDateTime).ToList();
        }
    }
}
