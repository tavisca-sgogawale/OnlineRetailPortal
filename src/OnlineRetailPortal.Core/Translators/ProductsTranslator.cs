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
