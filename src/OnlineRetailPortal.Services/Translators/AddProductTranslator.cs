using OnlineRetailPortal.Contracts;

namespace OnlineRetailPortal.Services
{
    public static class AddProductTranslator
    {
        public static Core.Product ToEntity(this AddProductRequest addProductRequest)
        {
            var product = new Core.Product(addProductRequest.Price.ToEntity(), addProductRequest.SellerId, addProductRequest.Name)
            {
                Description = addProductRequest.Description,
                HeroImage = addProductRequest.HeroImage,
                Category = addProductRequest.Category.ToEntity(),
                Images = addProductRequest.Images,
                PurchasedDate = addProductRequest.PurchasedDate,
                PickupAddress = addProductRequest.PickupAddress.ToEntity()
            };
            return product;
        }

        public static AddProductResponse ToModel(this Core.Product product)
        {
            AddProductResponse response = new AddProductResponse()
            {
                Id = product.Id,
                SellerId = product.SellerId,
                Name = product.Name,
                Description = product.Description,
                HeroImage = product.HeroImage,
                Price = product.Price.ToModel(),
                Category = product.Category.ToModel(),
                Status = product.Status.ToModel(),
                PostDateTime = product.PostDateTime,
                ExpirationDate = product.ExpirationDate,
                Images = product.Images,
                PurchasedDate = product.PurchasedDate,
                PickupAddress = product.PickupAddress.ToModel()
            };

            return response;
        }

    }
}
