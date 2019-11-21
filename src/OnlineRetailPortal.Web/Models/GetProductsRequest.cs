using System.Collections.Generic;

namespace OnlineRetailPortal.Web
{
    public class GetProductsRequest
    {
        public Sort ProductSort { get; set; }
        public List<Filter> Filters { get; set; }

    }
}
