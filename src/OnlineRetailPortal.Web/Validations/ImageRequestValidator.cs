using Microsoft.AspNetCore.Http;
using OnlineRetailPortal.Contracts;
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
        /// Checks if the incoming request is valid and throws an ImageUploadException if the request is invalid.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static void ValidateImagePostRequest(Microsoft.AspNetCore.Http.HttpRequest request)
        {

            try
            {
                int formFiles= request.Form.Files.Count;
            }
            catch (Exception ex)
            {
                if (ex.Message == "Request body too large.")
                {
                    throw new BaseException(StatusCodes.Status413PayloadTooLarge, "The sent file was too large..!\nLimit the Size to 24MB", null, System.Net.HttpStatusCode.BadRequest);
                }
                throw new BaseException(StatusCodes.Status400BadRequest, "No file was recieved or was sent with an invalid form key",null,System.Net.HttpStatusCode.BadRequest);
                //Log(ex.message, ex.trace)
            }


            if (request.Form.Files.Count > 0)
            {
                IFormFile file = request.Form.Files[0];
                if (file == null || !CheckIfImageFile(file))
                {
                    throw new BaseException(StatusCodes.Status415UnsupportedMediaType, "Invalid image file",null, System.Net.HttpStatusCode.BadRequest);

                }
            }
            else
            {
                throw new BaseException(StatusCodes.Status400BadRequest, "No file was recieved or was sent with an invalid form key",null, System.Net.HttpStatusCode.BadRequest);
            }

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
