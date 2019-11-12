using OnlineRetailPortal.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace OnlineRetailPortal.MongoDBStore
{
    public static class MongoEntityResponseTranslator
    {
        public static List<ProductEntity> ToModel(this List<MongoEntity> mongoEntity)
        {
            return mongoEntity.Select(x => new ProductEntity()
            {
                Id = x.Id,
                Description = x.Description,
                HeroImage = x.Gallery.HeroImageUrl,
                Images = x.Gallery.ImageUrls,
                Category = x.Category.ToModel(),
                Status = x.Status.ToStatusModel(),
                PostDateTime = x.CreatedDate,
                ExpirationDate = x.ExpirationDate,
                PurchasedDate = x.PurchasedDate,
                PickupAddress = x.PickupAddress
            }).ToList();
        }
    }
}
