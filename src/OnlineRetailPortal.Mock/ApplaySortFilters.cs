using System;
using System.Collections.Generic;
using System.Text;
using OnlineRetailPortal.Contracts;


namespace OnlineRetailPortal.Mock
{
    public  class  ApplaySortFilters
    {
        public  List<Product> ApplySort(List<Product> products, GetProductsEntity request)
        {
            switch (request.ProductSort.SortBy)
            {
                case "Name":

                    break;
                case "Category":

                    break;
                case "Price":

                    break;
                default:
                break;
            }
            return products;
        }

        public  List<Product> ApplyFilter(GetProductsEntity request, List<Product> productList)
        {
            if (request.Filters == null)
                return productList;
            return productList;
        }
    }
}
