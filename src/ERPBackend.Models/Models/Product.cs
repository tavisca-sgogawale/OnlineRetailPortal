using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPBackend.Models
{
    public class Product : IProduct
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Price Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Category Category { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Image HeroImage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Address PickupAddress { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Image> Images { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string UserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime PostDateTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime PurchasedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Status Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
