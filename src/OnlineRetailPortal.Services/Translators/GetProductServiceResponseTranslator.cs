using OnlineRetailPortal.Contracts;

namespace OnlineRetailPortal.Services
{
    public static class GetProductServiceResponseTranslator
    {
        public static GetProductServiceResponse ToServiceModel(this Core.Product getProductResponse)
        {
            GetProductServiceResponse response = new GetProductServiceResponse()
            {
                Product = new Product()
                {
                    Name = getProductResponse.Name,
                    Id = getProductResponse.Id,
                    HeroImage = getProductResponse.HeroImage,
                    ExpirationDate = getProductResponse.ExpirationDate,
                    PostDateTime = getProductResponse.PostDateTime,
                    Description = getProductResponse.Description,
                    Price = getProductResponse.Price.ToModel(),
                    PurchasedDate = getProductResponse.PurchasedDate,
                    PickupAddress = getProductResponse.PickupAddress.ToModel(),
                    Images = getProductResponse.Images,
                    Status = getProductResponse.Status.ToModel(),
                    Category = getProductResponse.Category.ToModel()
                }
            };
            return response;
        }
    }
}
