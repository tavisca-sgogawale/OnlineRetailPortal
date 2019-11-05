using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineRetailPortal.Contracts.Contracts;
using OnlineRetailPortal.Contracts.Models;
using OnlineRetailPortal.Web.Translators;
using OnlineRetailPortal.Web.Validations;

namespace OnlineRetailPortal.Web.Controllers
{
    [Route("api/v1.0/OnlineRetailPortal/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageHandler _imageHandler;
        public ImagesController(IImageHandler imageHandler)
        {
            _imageHandler = imageHandler;
        }

        // POST: api/Images
        [HttpPost]
        public async Task<IActionResult> UploadImage()
        {
            ImageRequestValidator.ValidateImagePostRequest(Request);

            IFormFile file = Request.Form.Files[0];
            UploadImageResponse response = await _imageHandler.UploadImage(file.ToUploadImageServiceContract());
            return response.ToUser();
            
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteImage(string id)
        {
            _imageHandler.DeleteTempImage(id.ToDeleteImageContract());
            return new StatusCodeResult(204);

        }

    }


}
