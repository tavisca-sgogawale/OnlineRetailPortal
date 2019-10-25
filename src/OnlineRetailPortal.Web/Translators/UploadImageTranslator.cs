using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineRetailPortal.Contracts.Contracts;
using Newtonsoft.Json;

namespace OnlineRetailPortal.Web.Translators
{
    public static class UploadImageTranslator
    {
        public static UploadImageRequest ToUploadImageContract(this IFormFile file)
        {
            var request = new UploadImageRequest() { File = file};
            return request;
        }

        public static IActionResult ToUser(this UploadImageResponse response)
        {
            var result = JsonConvert.SerializeObject(response);
            if (response.Code == StatusCodes.Status200OK)
            {

                return new OkObjectResult(result);
            }
            else if (response.Code == StatusCodes.Status400BadRequest)
            {
                return new BadRequestObjectResult(result);

            }
            else
                return new ObjectResult(result) { StatusCode=StatusCodes.Status500InternalServerError};


        }
    }
}
