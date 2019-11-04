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
                //throw new BaseException(StatusCodes.Status400BadRequest, "No file was recieved or was sent with an invalid form key",null,400);
                //Log(ex.message, ex.trace)
            }


            if (request.Form.Files.Count > 0)
            {
                IFormFile file = request.Form.Files[0];
                if (file == null || !CheckIfImageFile(file))
                {
                    //throw new BaseException(StatusCodes.Status415UnsupportedMediaType, "Invalid image file",null,400);

                }
            }
            else
            {
                //throw new BaseException(StatusCodes.Status400BadRequest, "No file was recieved or was sent with an invalid form key",null,400);
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
