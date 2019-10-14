using ERPBackend.Models;
using System;
using System.Collections.Generic;

public interface IProductProvider
{
    List<Product> GetProductsByPage(int pageNumber, int pageSize);
    Product GetProductById(int Id);
}
