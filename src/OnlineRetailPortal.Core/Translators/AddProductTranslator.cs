using OnlineRetailPortal.Contracts;
namespace OnlineRetailPortal.Core
{
    public static class AddProductTranslator
    {
        public static ProductEntity ToEntity(this Product product)
        {
            var addProductStoreRequest = new ProductEntity()
            {
                SellerId = product.SellerId,
                Name = product.Name,
                Description = product.Description,
                HeroImage = product.HeroImage,
                Price = product.Price.ToEntity(),
                Category = product.Category.ToEntity(),
                Images = product.Images,
                PurchasedDate = product.PurchasedDate,
                PickupAddress = product.PickupAddress.ToEntity()

            };

            return addProductStoreRequest;
        }


        public static Product ToModel(this ProductEntity addProductStoreResponse)
        {
            var product = new Product(addProductStoreResponse.Price.ToModel(), addProductStoreResponse.SellerId, addProductStoreResponse.Name)
            {
                Id = addProductStoreResponse.Id,
                Description = addProductStoreResponse.Description,
                HeroImage = addProductStoreResponse.HeroImage,
                Category = addProductStoreResponse.Category.ToModel(),
                Status = addProductStoreResponse.Status.ToModel(),
                PostDateTime = addProductStoreResponse.PostDateTime,
                ExpirationDate = addProductStoreResponse.ExpirationDate,
                Images = addProductStoreResponse.Images,
                PurchasedDate = addProductStoreResponse.PurchasedDate,
                PickupAddress = addProductStoreResponse.PickupAddress.ToModel()
            };

            return product;
        }
    }
}
