using Microsoft.AspNetCore.Http;
using OnlineRetailPortal.Contracts.Contracts;
using OnlineRetailPortal.Contracts.Models;
using OnlineRetailPortal.Web.Models;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace OnlineRetailPortal.Web.Validations
{
    public static class ImageRequestValidator
    {
        /// <summary>
        /// Returns true if the Request is a Valid Response else returns false and updates the "respose" variable with response messages
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        public static bool IsValidPostRequest(Microsoft.AspNetCore.Http.HttpRequest request, Contracts.Contracts.UploadImageResponse response)
        {
            if (request.Form.Files.Count > 0)
            {
                IFormFile file = request.Form.Files[0];

                if (file != null && CheckIfImageFile(file))
                {
                    return true;
                }
                response = new UploadImageResponse() { Code = StatusCodes.Status415UnsupportedMediaType, Message = "Invalid image file" };
                response.info[0]=new ImageWriterFailResponse() { Code = StatusCodes.Status415UnsupportedMediaType, Response = "Invalid image file or Corrupted file recieved" };

            }
            else
            {
                response = new UploadImageResponse { Code = StatusCodes.Status400BadRequest, Message = "No file was recieved" };
                response.info[0] = new ImageWriterFailResponse() { Code = StatusCodes.Status400BadRequest, Response = "No file was recieved or was sent with an invalid form key" };
            }
            return false;

        }

        /// <summary>
        /// Method to check if file is a valid image file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private static bool CheckIfImageFile(IFormFile file)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            return SupportedImageFormats.GetImageFormat(fileBytes) != SupportedImageFormats.ImageFormat.unknown;
        }
    }
}
