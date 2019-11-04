﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineRetailPortal.Contracts.Contracts;
using Newtonsoft.Json;

namespace OnlineRetailPortal.Web.Translators
{
    public static class UploadImageTranslator
    {
        public static UploadImageRequest ToUploadImageServiceContract(this IFormFile file)
        {
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
            var result = JsonConvert.SerializeObject(response);
            return new OkObjectResult(result);
        }
    }
}
