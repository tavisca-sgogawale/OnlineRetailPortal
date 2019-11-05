using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using OnlineRetailPortal.Contracts.Contracts;
using OnlineRetailPortal.Contracts.Models;

namespace OnlineRetailPortal.Services.Translators
{
    public static class ImageHandlerWriterTranslator
    {

        public static UploadImageResponse ToUploadImageResponse(this ImageWriterResponse response)
        {
            UploadImageResponse uploadImageResponse = new UploadImageResponse() { Message = response.Response};
            return uploadImageResponse;
        }
    }
}
