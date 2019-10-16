using ERPBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPBackend.Services
{
    public interface IProductService
    {
        Product AddProduct(Product product);
    }
}
