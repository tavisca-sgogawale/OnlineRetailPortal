using OnlineRetailPortal.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web
{
    public class CategoryResponse : ICategoryResponse
    {
        public List<Category> Categories { get; set; }
        public string Message { get; set; }

        public int Status { get; set; }

    }
}
