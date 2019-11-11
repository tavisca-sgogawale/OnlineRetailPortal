using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Web.Translators;
using OnlineRetailPortal.Web.Validations;

namespace OnlineRetailPortal.Web.Controllers
{
    [Route("api/v1.0/OnlineRetailPortal")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;
        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        // POST: api/Images
        [HttpPost("images")]
        public async Task<IActionResult> UploadImage()
        {
            UploadImageRequestValidator validator = new UploadImageRequestValidator();
            ImageRequestValidator.Validate(validator, Request);

            UploadImageResponse response = await _imageService.UploadImageAsync(Request.ToEntity());
            return response.ToUser();
            
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("images/{id}")]
        public IActionResult DeleteImage(string id)
        {
            DeleteImageRequestValidator requestValidator = new DeleteImageRequestValidator();
            requestValidator.ValidateDeleteRequest(id);

            _imageService.DeleteImage(id.ToDeleteImageContract());
            return new StatusCodeResult(204);

        }

    }


}
