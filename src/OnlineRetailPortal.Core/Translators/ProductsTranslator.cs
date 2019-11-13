using OnlineRetailPortal.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace OnlineRetailPortal.Core
{
    public static class ProductsTranslator
    {
        public static List<Product> ToModel(this List<ProductEntity> products)
        {
            return products.Select(x => new Product(x.Price.ToModel(), x.SellerId, x.Name)
            {
                Id = x.Id,
                Description = x.Description,
                HeroImage = x.HeroImage,
                Images = x.Images,
                Status = x.Status.ToModel(),
                PostDateTime = x.PostDateTime,
                ExpirationDate = x.ExpirationDate,
                PurchasedDate = x.PurchasedDate,
                PickupAddress = x.PickupAddress.ToModel()
            }).ToList();
        }
    }
}
