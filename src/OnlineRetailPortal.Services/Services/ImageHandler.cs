using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineRetailPortal.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Services.Services
{
    public class ImageHandler : IImageHandler
    {
        private readonly IImageWriter _imageWriter;
        private IHostingEnvironment _env;
        public ImageHandler(IImageWriter imageWriter, IHostingEnvironment env)
        {
            _imageWriter = imageWriter;
            _env = env;
        }


        public async Task<UploadImageResponse> UploadImage(UploadImageRequest request)
        {
            IFormFile file = request.File;
            var response=  await _imageWriter.UploadImage(file).ConfigureAwait(false);
            return new UploadImageResponse() { Success = response.Success, Message = response.Response };
        }


        public async void DeleteImage(DeleteImageRequest request)
        {
            string imageId = request.ImageID;
            try
            {
                var webRootPath = _env.WebRootPath;
                var imgPath = "\\tempImages\\" + imageId ;
                var completePath = webRootPath + imgPath;
                File.Delete(completePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Delete request: {@ex} ", ex);

                //Logger.logInformation("Invalid Delete request: {@ex} ", ex)
            }

        }
    }
}
