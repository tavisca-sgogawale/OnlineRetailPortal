using ERPBackend.Models;
using System.Collections.Generic;

public interface IProductProvider
{
    List<Product> GetProductsByPage(int pageNumber, int pageSize);
    Product GetProductById(string Id);
    void AddProduct(Product product);
}
