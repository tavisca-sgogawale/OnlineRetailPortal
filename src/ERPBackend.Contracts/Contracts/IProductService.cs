using ERPBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPBackend.Contracts.Contracts
{
    public interface IProductService
    {
        Product AddProduct(Product product);
    }
}
