using ERPBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class MockProductDatabase : IProductProvider
{
    List<Product> _productList = new List<Product>
        {
            new Product{Id=101,Name="Mobile", Price=new Price{ Amount=1299.00, IsNegotiable=true}, Category=Category.Mobiles,
                HeroImage =new Image{Url = "https://www.olx.in/item/11-pro-max-64-gb-full-box-iid-1540782056/gallery"},
                Description ="11 pro max 64 gb full box", Images=null,
                PickupAddress =new Address{Line1="abc",Line2="xyz", City="Pune",State="Maharashtra", Pincode=411038 },
                PostDateTime =  new DateTime(2019,12,1), PurchasedDate = new DateTime(2019,12,1), Status = Status.Active, UserId = "1118" },

            new Product{Id=102,Name="Bottle", Price=new Price{ Amount=999.00, IsNegotiable=true}, Category=Category.Others,
                HeroImage =new Image{Url = "https://www.olx.in/item/11-pro-max-64-gb-full-box-iid-1540782056/gallery"},
                Description ="Tavisca green color bottle", Images=null,
                PickupAddress =new Address{Line1="abc",Line2="xyz", City="Pune",State="Maharashtra", Pincode=411038 },
                PostDateTime =  new DateTime(2019,12,1), PurchasedDate =  new DateTime(2019,12,1), Status = Status.Active, UserId = "1118" }

        };
    public Product GetProductById(int Id)
    {
        Product product = _productList.Where(n => n.Id == Id).First();
        return product;
    }
    public List<Product> GetProductsByPage(int pageNumber, int pageSize)
    {
        return _productList;
    }
    public void AddProduct(Product product)
    {
        _productList.Add(product);
    }
}