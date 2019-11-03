using OnlineRetailPortal.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web.Models
{
    public class CategoryFailResponse : ICategoryResponse
    {
        
        public string Message { get; set; }

        public int Status { get; set; }
    }
}
