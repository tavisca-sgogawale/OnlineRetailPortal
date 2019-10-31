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
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageHandler _imageHandler;
        private IWebHostEnvironment _env;
        public ImagesController(IImageHandler imageHandler, IWebHostEnvironment env)
        {
            _imageHandler = imageHandler;
            _env = env;
        }

        // POST: api/Images
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            UploadImageResponse response= null;

            if (ImageRequestValidator.IsValidPostRequest(Request,response))
            {
                IFormFile file = Request.Form.Files[0];
                response = await _imageHandler.UploadImage(file.ToUploadImageContract()).ConfigureAwait(false);
            }

            return response.ToUser();
        }

        /// <summary>
        /// Image path should be sent in the URL in the form "api/controller/imageName.jpg "
        /// </summary>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _imageHandler.DeleteTempImage(id.ToDeleteImageContract());
        }





        // GET: api/Images
        [HttpGet]
        public IEnumerable<string> Get()
        {
            
            return new string[] { _env.WebRootPath,"value2" };
        }

        // GET: api/Images/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT: api/Images/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }

    public class ImgUrl
    {
        string bodyImageId;
    
    }
}
