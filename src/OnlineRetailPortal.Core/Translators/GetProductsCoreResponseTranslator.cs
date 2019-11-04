using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRetailPortal.Core
{
    public static class GetProductsCoreResponseTranslator
    {

        public static ProductsWithPageInitiation ToProductsWithPageInitiation(this GetProductsStoreResponse getProductResponse)
        {
            ProductsWithPageInitiation responce = new ProductsWithPageInitiation()
            {
                Products = getProductResponse.Products.Select(x => new Product(new Price() {
                    Amount = x.Price.Amount,
                    IsNegotiable = x.Price.IsNegotiable,
                    Currency = x.Price.Currency
                }, x.UserId, x.Name)
                {
                    Id = x.Id,
                    HeroImage = new Image() { Url = x.HeroImage.Url },
                    ExpirationDate = x.ExpirationDate,
                    PostDateTime = x.PostDateTime,
                    Description = x.Description,
                    PurchasedDate = x.PurchasedDate,
                    PickupAddress = new Address()
                    {
                        City = x.PickupAddress.City,
                        State = x.PickupAddress.State,
                        Line1 = x.PickupAddress.Line1,
                        Line2 = x.PickupAddress.Line2,
                        Pincode = x.PickupAddress.Pincode
                    },
                    Images = x.Images.Select(y => new Image
                    {
                        Url = y.Url
                    }).ToList(),
                    Status = (Status)x.Status.GetHashCode(),
                    Category = (Category)x.Category.GetHashCode()
                }).ToList(),
                PagingInfo = new PagingInfo()
                {
                    PageNumber = getProductResponse.PagingInfo.PageNumber,
                    PageSize = getProductResponse.PagingInfo.PageSize,
                    SortBy = (SortBy)getProductResponse.PagingInfo.SortBy
                }
            };
            return responce;
        }
    }
}