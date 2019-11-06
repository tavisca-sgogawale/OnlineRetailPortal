﻿using OnlineRetailPortal.Contracts.Contracts;


namespace OnlineRetailPortal.Web.Translators
{
    public static class DeleteImageRequestTranslator
    {
        public static DeleteImageRequest ToDeleteImageContract(this string imageId)
        {
            var request = new DeleteImageRequest() { ImageID=imageId };
            return request;
        }
    }
}