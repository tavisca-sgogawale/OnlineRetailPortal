using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPBackend.Models
{
    public class Advertisement
    {
        public int Id { get; set; }
        public Price Price { get; set; }
        public Category Category { get; set; }
        

    }
}
