using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web
{
    public class GetProductRequest
    {
        public Sort ProductSort { get; set; }

        public List<Filter> Filters { get; set; }
    }
}
