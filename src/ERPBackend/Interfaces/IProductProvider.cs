using ERPBackend.Models;
using System.Collections.Generic;

public interface IProductProvider
{
    List<Product> GetProductsByPage(int pageNumber, int pageSize);
<<<<<<< HEAD:src/ERPBackend/Interfaces/IProductProvider.cs
    Product GetProductById(string Id);
    Product AddProduct(Product product);
=======
   // List<Product> GetProducts(int pageNumber, int pageSize);
    Product GetProductById(int Id);
>>>>>>> 1a20098234ad1f87a3e8da55b09df840e3b32209:src/ERPBackend/Services/IProductProvider.cs
}
