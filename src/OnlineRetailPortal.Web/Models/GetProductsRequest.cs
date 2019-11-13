using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web
{
    [DataContract]
    public class GetProductsRequest
    {
        public ProductSort ProductSort { get; set; }
        public List<Filter> Filters { get; set; }

    }
}
