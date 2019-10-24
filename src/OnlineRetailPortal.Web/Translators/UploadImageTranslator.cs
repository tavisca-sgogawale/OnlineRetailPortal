using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineRetailPortal.Contracts.Contracts;
using System.Threading.Tasks;

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
            if (response.Success)
            {
                return new OkObjectResult(response);
            }
            else
            {
                return new BadRequestObjectResult(response);

            }


        }
    }
}
