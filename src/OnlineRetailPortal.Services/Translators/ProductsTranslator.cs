using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRetailPortal.Services
{
   public static class ProductsTranslator
    {
        public static List<Product> ToModel(this List<Core.Product> products)
        {
            return products.Select(x => new Product()
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
