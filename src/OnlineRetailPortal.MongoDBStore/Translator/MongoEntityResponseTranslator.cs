using OnlineRetailPortal.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace OnlineRetailPortal.MongoDBStore
{
    public static class MongoEntityResponseTranslator
    {
        public static GetProductsStoreResponse ToModel(this List<MongoEntity> mongoEntity, PagingInfo pagingInfo)
        {
            if (mongoEntity == null)
                return null;
            GetProductsStoreResponse getProductsStoreResponse = new GetProductsStoreResponse()
            {
                Products = mongoEntity.Select(x => new ProductEntity()
                {
                    Id = x.Id,
                    Description = x.Description,
                    HeroImage = x.Gallery.HeroImageUrl,
                    Images = x.Gallery.ImageUrls,
                    Price=x.Price.ToModel(),
                    Category=x.Category.ToModel(),
                    SellerId=x.SellerId,
                    Name=x.Name,
                    Status = x.Status.ToStatusModel(),
                    PostDateTime = x.CreatedDate,
                    ExpirationDate = x.ExpirationDate,
                    PurchasedDate = x.PurchasedDate,
                    PickupAddress = x.PickupAddress
                }).ToList(),
                PagingInfo = new PagingInfo()
                {
                    PageNumber = pagingInfo.PageNumber,
                    PageSize = pagingInfo.PageSize,
                    TotalPages = pagingInfo.TotalPages
                }
            };
            return getProductsStoreResponse;
        }
    }
}
