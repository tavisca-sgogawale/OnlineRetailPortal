using ERPBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPBackend.Services
{
    public class ProductService : IProductService
    {
        IProductProvider productProvider;
        public ProductService(IProductProvider mockProvider)
        {
            productProvider = mockProvider;
        }
        public Product AddProduct(Product product)
        {
            return productProvider.AddProduct(product);
        }
    }
}
