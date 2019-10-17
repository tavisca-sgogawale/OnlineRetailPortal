
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPBackend.Services
{
    public interface IProductProvider
    {
        List<Product> GetProductsByPage(int pageNumber, int pageSize);
        Product GetProductById(string Id);
        Product AddProduct(Product product);
        Product GetProductById(int Id);
    }
}
