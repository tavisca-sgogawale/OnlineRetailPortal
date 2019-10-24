using OnlineRetailPortal.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Contracts.Contracts
{
    public interface IProductStore
    {
        List<Product> getProducts(int pagenumber, int pagesize);
        Product getProduct(string productId);
    }
}
