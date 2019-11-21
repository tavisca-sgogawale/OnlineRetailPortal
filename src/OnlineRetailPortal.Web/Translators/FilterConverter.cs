using Newtonsoft.Json.Linq;
using System;

namespace OnlineRetailPortal.Web
{
    public class FilterConverter : AbstractJsonConverter<Filter>
    {
        protected override JsonResponse Create(Type objectType, JObject jObject)
        {
            if (FieldExists(jObject, "Search", JTokenType.Object))
                return new JsonResponse(new SearchFilter(), "Search");

            if (FieldExists(jObject, "Id", JTokenType.Object))
                return new JsonResponse(new IdFilter(), "Id");

            if (FieldExists(jObject, "Price", JTokenType.Object))
                return new JsonResponse(new PriceFilter(), "Price");

            if (FieldExists(jObject, "Status", JTokenType.Object))
                return new JsonResponse(new StatusFilter(), "Status");
            throw new InvalidOperationException();
        }
    }
}