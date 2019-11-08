using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRetailPortal.Core
{
   public static class ProductsTranslator
    {
        public static List<Product> ToModel(this List<Contracts.Product> products)
        {
            return products.Select(x => new Product(x.Price.ToModel(), x.SellerId, x.Name)
            {
                Id = x.Id,
                HeroImage = x.HeroImage,
                PostDateTime = x.PostDateTime,
            }).ToList();
        }
    }
}
