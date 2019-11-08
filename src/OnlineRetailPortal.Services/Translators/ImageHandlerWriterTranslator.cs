using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Contracts;

namespace OnlineRetailPortal.Services.Translators
{
    public static class ImageHandlerWriterTranslator
    {

        public static UploadImageResponse ToModel(this ImageWriterResponse response)
        {
            UploadImageResponse uploadImageResponse = new UploadImageResponse() { ImageUrl = response.Response};
            return uploadImageResponse;
        }
    }
}
