using OnlineRetailPortal.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Core
{
    public class DisplayProduct
    {
        static List<Product> _productList = new List<Product>();
        public List<Product> GetAllProducts()
        {
            if (_productList.Count == 0)
            {
                return null;
            }
            return _productList;
        }
        public static async Task<Product> GetProductById(int productId)
        {
            Product Product = _productList.SingleOrDefault(x => x.Id == productId);
            if (Product == null)
            {
                return null;
            }
            return Product;
        }
        public List<Product> SortProductListByDateTime()
        {
            List<Product> sortedDateList = new List<Product>();
            var data=_productList.OrderByDescending(x => x.PostDateTime).Take(50);
            foreach (var date in _productList.OrderByDescending(x => x))
            {
                sortedDateList.Add(date);
            }
            return sortedDateList;
        }

        public bool IsProductAvaiLabel(Product _product)
        {
            if (_product.Status.Equals(Status.Active))
            {
                return true;
            }
            return false;
        }
    }
}
