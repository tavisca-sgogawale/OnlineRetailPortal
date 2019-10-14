using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPBackend.Controllers
{
    [Route("api/v1.0/txs/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductProvider _productDb;

        public ProductsController(MockProductDatabase mockProduct)
        {
            _productDb = mockProduct;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetProductsByPage(int pageNumber,int pageSize) =>
            _productDb.GetProductsByPage(pageNumber, pageNumber);

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = _productDb.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return product;

        }
            
    }
}