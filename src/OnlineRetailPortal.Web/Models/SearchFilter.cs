using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace OnlineRetailPortal.Web
{
    public class SearchFilter : Filter
    {
        public string SearchQuery { get; set; }
    }
}