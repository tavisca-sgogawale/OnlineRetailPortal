using OnlineRetailPortal.Contracts;

namespace OnlineRetailPortal.Core
{
    public static class GetProductServiceResponseTranslator
    {
        public static Product ToModel(this GetProductStoreResponse getProductResponse)
        {
            Price price = getProductResponse.Product.Price.ToModel();
            Product response = new Product(price, getProductResponse.Product.SellerId, getProductResponse.Product.Name)

            {
                Id = getProductResponse.Product.Id,
                HeroImage = getProductResponse.Product.HeroImage,
                ExpirationDate = getProductResponse.Product.ExpirationDate,
                PostDateTime = getProductResponse.Product.PostDateTime,
                Description = getProductResponse.Product.Description,
                PurchasedDate = getProductResponse.Product.PurchasedDate,
                PickupAddress = getProductResponse.Product.PickupAddress.ToModel(),
                Images = getProductResponse.Product.Images,
                Status = getProductResponse.Product.Status.ToModel(),
                Category = getProductResponse.Product.Category.ToModel()

            };

            return response;
        }

    }
}

