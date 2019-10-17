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

        public ProductsController(IProductProvider product)
        {
            _productDb = product;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetProductsByPage(int pageNumber,int pageSize)
        {
            try
            {
                return _productDb.GetProductsByPage(pageNumber, pageSize);
            }
            catch(IndexOutOfRangeException e)
            {
                return NotFound("Insert Correct Page No.");
            }


        }
           

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