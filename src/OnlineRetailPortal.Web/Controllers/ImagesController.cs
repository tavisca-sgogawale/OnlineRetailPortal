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
        [HttpPost("image")]
        public async Task<IActionResult> UploadImage()
        {
            UploadImageRequestValidator validator = new UploadImageRequestValidator();
            validator.EnsureValidity(Request);

            UploadImageResponse response = await _imageService.UploadImageAsync(Request.ToEntity());
            return response.ToUser();
            
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("image/{id}")]
        public IActionResult DeleteImage(string id)
        {
            DeleteImageRequestValidator requestValidator = new DeleteImageRequestValidator();
            requestValidator.ValidateDeleteRequest(id);

            _imageService.DeleteImage(id.ToDeleteImageContract());
            return new StatusCodeResult(204);

        }

        //Move images from temporary to permanent storage
        // POST: api/Images
        [HttpPost("image/store")]
        public void MoveImages([FromBody] MoveImagesRequest request)
        {
            MoveImageRequestValidator validator = new MoveImageRequestValidator();
            validator.EnsureMoveValidity(request);

            _imageService.MoveToStorage(request.HeroImageUrl);
            _imageService.MoveToStorage(request.ImageUrls);

        }

    }


}
