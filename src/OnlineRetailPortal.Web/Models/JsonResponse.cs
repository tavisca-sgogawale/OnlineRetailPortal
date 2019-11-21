namespace OnlineRetailPortal.Web
{
    public class JsonResponse
    {
        public JsonResponse(object target, string key)
        {
            Target = target;
            Key = key;
        }

        public object Target { get; set; }
        public string Key { get; set; }
    }
}
