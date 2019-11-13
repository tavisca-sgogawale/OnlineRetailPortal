using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineRetailPortal.Contracts;
using Newtonsoft.Json;

namespace OnlineRetailPortal.Web.Translators
{
    public static class UploadImageTranslator
    {
        public static UploadImageRequest ToEntity(this Microsoft.AspNetCore.Http.HttpRequest httpRequest)//(this IFormFile file)
        {
            IFormFile file = httpRequest.Form.Files[0];

            var request = new UploadImageRequest() { File = file};
            return request;
        }
        /// <summary>
        /// Converts the server response into Json object as per the API Contract.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static IActionResult ToUser(this UploadImageResponse response)
        {
            return new OkObjectResult(response);
        }
    }
}
