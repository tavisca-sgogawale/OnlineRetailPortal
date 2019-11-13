using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web
{
    public static class GetProductsResponseTranslator
    {
        public static GetProductsResponse ToGetProductsContract(this Contracts.GetProductsServiceResponse getProductsServiceResponse)
        {
            GetProductsResponse response = new GetProductsResponse()
            {
                Products = getProductsServiceResponse.Products.ToEntity(),
                PagingInfo = getProductsServiceResponse.PagingInfo.ToEntity()
            };
            return response;
        }
        public static PagingInfo ToEntity(this Contracts.PagingInfo pagingInfo)
        {
            return new PagingInfo()
            {
                PageNumber = pagingInfo.PageNumber,
                PageSize = pagingInfo.PageSize,
                TotalPages = pagingInfo.TotalPages
            };
        }
        public static List<Product> ToEntity(this List<Contracts.Product> products)
        {
            return  products.Select(x => new Product()
            {
                Id = x.Id,
                Description = x.Description,
                HeroImage = x.HeroImage,
                Images = x.Images,
                Price = x.Price.ToModel(),
                Category = x.Category.ToModel(),
                SellerId = x.SellerId,
                Name = x.Name,
                Status = x.Status.ToModel(),
                PostDateTime = x.PostDateTime,
                ExpirationDate = x.ExpirationDate,
                PurchasedDate = x.PurchasedDate,
                PickupAddress = x.PickupAddress.ToModel()
            }).ToList();
        }
    }
    

}