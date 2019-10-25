using OnlineRetailPortal.Contracts.Models;
using OnlineRetailPortal.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRetailPortal.Core.Translators
{
    public static class Translator
    {
        public static GetProductsRequest ToEntity(this GetProductsRequest request)
        {
            if (request.Page == null)
            {
                return null;
            }
            var getProductRequest = new GetProductsRequest()
            {
                Page = new Contracts.Models.Page()
                {
                    PageNumber = request.Page.PageNumber,
                    PageSize = request.Page.PageSize,
                    SortBy = request.Page.SortBy
                }
            };
            return getProductRequest;
        }

        public static GetProductsResponse ToProductsList(List<Core.Models.Product> products)
        {
            var getProductsResponse = new GetProductsResponse()
            {
                products = GetList(products)
            };
            return getProductsResponse;
           
        }

        private static List<Contracts.Models.ProductList> GetList(List<Models.Product> products)
        {
            List<Contracts.Models.ProductList> productLists = new List<Contracts.Models.ProductList>();
            for (int i=0;i<products.Count;i++)
            {
                productLists[i].Id = products[i].Id;
                productLists[i].Name = products[i].Name;
                productLists[i].Price =new Contracts.Models.Price { Amount =products[i].Price.Amount, isPriceNegotiable = products[i].Price.isPriceNegotiable, Currency = (Contracts.Models.Currency) products[i].Price.Currency};
                productLists[i].Category = (Contracts.Models.Category)products[i].Category;
                productLists[i].HeroImage = new Contracts.Models.Image { Url = products[i].HeroImage.Url };
                productLists[i].PickupAddress = new Contracts.Models.Address { Line1 = products[i].PickupAddress.Line1, Line2 = products[i].PickupAddress.Line2, State= products[i].PickupAddress.State , City = products[i].PickupAddress.City,pu
                =products[i].PickupAddress.Pincode};
                productLists[i].PostDateTime = products[i].PostDateTime;
                productLists[i].Status = (Contracts.Models.Status)products[i].Status;
            }
            return productLists;
        }
    }
}
