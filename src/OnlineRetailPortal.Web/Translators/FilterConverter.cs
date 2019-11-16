using Newtonsoft.Json.Linq;
using System;

namespace OnlineRetailPortal.Web
{
    public class FilterConverter : AbstractJsonConverter<Filter>
    {
        protected override Filter Create(Type objectType, JObject jObject)
        {
            if (FieldExists(jObject, "SearchQuery", JTokenType.String))
                return new SearchFilter();

            if (FieldExists(jObject, "SellerId", JTokenType.String))
                return new IdFilter();

            if (FieldExists(jObject, "Min", JTokenType.String))
                return new PriceFilter();

            throw new InvalidOperationException();
        }
    }
}