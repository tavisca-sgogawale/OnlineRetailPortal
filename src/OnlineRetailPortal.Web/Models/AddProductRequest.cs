using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web
{
    public class AddProductRequest
    {
        public string UserId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public Price Price { get; set; }
        public string Description { get; set; }
        public DateTime PurchasedDate { get; set; }
        public Image HeroImage { get; set; }
        public List<Image> Images { get; set; }
        public Address PickupAddress { get; set; }
    }
}
