using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace OnlineRetailPortal.Web
{
    public abstract class AbstractJsonConverter<T> : JsonConverter
    {
        protected abstract JsonResponse Create(Type objectType, JObject jObject);

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            JsonResponse response = Create(objectType, jObject);
            JToken token;
            jObject.TryGetValue(response.Key, StringComparison.InvariantCultureIgnoreCase, out token);
            serializer.Populate(token.CreateReader(), response.Target);

            return response.Target;
        }

        public override void WriteJson(
            JsonWriter writer,
            object value,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        protected static bool FieldExists(
            JObject jObject,
            string name,
            JTokenType type)
        {
            JToken token;
            return jObject.TryGetValue(name, out token) && token.Type == type;
        }
    }
}