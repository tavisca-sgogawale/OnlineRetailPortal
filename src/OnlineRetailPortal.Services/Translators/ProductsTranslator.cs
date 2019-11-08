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
                Name = x.Name,
                Id = x.Id,
                HeroImage = x.HeroImage,
                PostDateTime = x.PostDateTime,
                Price = x.Price.ToModel(),
            }).ToList();
        }
    }
}
