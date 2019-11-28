using OnlineRetailPortal.Contracts;

namespace OnlineRetailPortal.MongoDBStore
{
    public static class ProductStoreTranslator
    {
        public static MongoEntity ToEntity(this ProductEntity productEntity)
        {
            MongoEntity mongoEntity = new MongoEntity
            {
                Id = productEntity.Id,
                SellerId = productEntity.SellerId,
                Name = productEntity.Name,
                Category = productEntity.Category.ToEntity(),
                Description = productEntity.Description,
                Gallery = new Gallery() { HeroImageUrl = productEntity.HeroImage, ImageUrls = productEntity.Images },
                Price = productEntity.Price.ToEntity(),
                Status = productEntity.Status.ToStatusEntity(),
                CreatedDate = productEntity.PostDateTime,
                ExpirationDate = productEntity.ExpirationDate,
                PurchasedDate = productEntity.PurchasedDate,
                PickupAddress = productEntity.PickupAddress.ToEntity()
            };
            return mongoEntity;
        }
        public static GetProductStoreResponse ToGetResponseModel(this MongoEntity mongoEntity)
        {
            if (mongoEntity == null)
                return null;
            GetProductStoreResponse getProductStoreResponse = new GetProductStoreResponse()
            {
                Product = new ProductEntity()
                {
                    Id = mongoEntity.Id,
                    SellerId = mongoEntity.SellerId,
                    Name = mongoEntity.Name,
                    Category = mongoEntity.Category.ToModel(),
                    Description = mongoEntity.Description,
                    HeroImage = mongoEntity.Gallery.HeroImageUrl,
                    Images = mongoEntity.Gallery.ImageUrls,
                    Price = mongoEntity.Price.ToModel(),
                    Status = mongoEntity.Status.ToStatusModel(),
                    PostDateTime = mongoEntity.CreatedDate,
                    ExpirationDate = mongoEntity.ExpirationDate,
                    PurchasedDate = mongoEntity.PurchasedDate,
                    PickupAddress = mongoEntity.PickupAddress.ToModel()
                }
            };
            return getProductStoreResponse;
        }
        public static ProductEntity ToModel(this MongoEntity mongoEntity)
        {
            if (mongoEntity == null)
                return null;
            ProductEntity productEntity = new ProductEntity
            {
                Id = mongoEntity.Id,
                SellerId = mongoEntity.SellerId,
                Name = mongoEntity.Name,
                Category = mongoEntity.Category.ToModel(),
                Description = mongoEntity.Description,
                HeroImage = mongoEntity.Gallery.HeroImageUrl,
                Images = mongoEntity.Gallery.ImageUrls,
                Price = mongoEntity.Price.ToModel(),
                Status = mongoEntity.Status.ToStatusModel(),
                PostDateTime = mongoEntity.CreatedDate,
                ExpirationDate = mongoEntity.ExpirationDate,
                PurchasedDate = mongoEntity.PurchasedDate,
                PickupAddress = mongoEntity.PickupAddress.ToModel()
            }; 
            return productEntity;
        }
    }

}
