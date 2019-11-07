using OnlineRetailPortal.Contracts;


namespace OnlineRetailPortal.Web.Translators
{
    public static class DeleteImageRequestTranslator
    {
        public static DeleteImageRequest ToDeleteImageContract(this string imageId)
        {
            var request = new DeleteImageRequest() { ImageId=imageId };
            return request;
        }
    }
}
