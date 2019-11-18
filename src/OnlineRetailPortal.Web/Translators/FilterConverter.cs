using Newtonsoft.Json.Linq;
using System;

namespace OnlineRetailPortal.Web
{
    public class FilterConverter : AbstractJsonConverter<Contracts.Filter>
    {
        protected override Contracts.Filter Create(Type objectType, JObject jObject)
        {
            if (FieldExists(jObject, "SearchQuery", JTokenType.String))
                return new Contracts.SearchFilter();

            if (FieldExists(jObject, "SellerId", JTokenType.String))
                return new Contracts.IdFilter();

            if (FieldExists(jObject, "Min", JTokenType.Integer))
                return new Contracts.PriceFilter();

            if (FieldExists(jObject, "Status", JTokenType.String))
                return new Contracts.StatusFilter();
            throw new InvalidOperationException();
        }
    }
}