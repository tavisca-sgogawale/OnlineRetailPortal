using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using OnlineRetailPortal.Contracts.Contracts;

namespace OnlineRetailPortal.Services.Translators
{
    public static class ImageHandlerWriterTranslator
    {

        public static UploadImageResponse ToUploadImageResponse(this IImageWriterResponse response)
        {
            UploadImageResponse uploadImageResponse = new UploadImageResponse();

            if (response.Code == StatusCodes.Status200OK)
            {
                uploadImageResponse.Code = StatusCodes.Status200OK;
                uploadImageResponse.Message = response.Response;
            }
            else if (response.Code == StatusCodes.Status415UnsupportedMediaType)
            {
                uploadImageResponse.Code = StatusCodes.Status400BadRequest;
                uploadImageResponse.Message = "The image is not in the correct format or is Corrupt";
                uploadImageResponse.info[0] = response;
            }
            else
            {
                uploadImageResponse.Code = StatusCodes.Status500InternalServerError;
                uploadImageResponse.Message = "Oops! Somthing Went Wrong.!";

                uploadImageResponse.info[0] = response;

            }
            return uploadImageResponse;

        }
    }
}
