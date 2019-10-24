using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private string _tempImagefolder;

        public ImageHandler(IImageWriter imageWriter, IHostingEnvironment env, IConfiguration iconfig)
        {
            _imageWriter = imageWriter;
            _env = env;
            _tempImagefolder = iconfig.GetSection("TempImageFolder").Value;
        }

        /// <summary>
        /// Takes an UploadImageRequest type object and tries to save the image in it
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UploadImageResponse> UploadImage(UploadImageRequest request)
        {

            IFormFile file = request.File;
            var response=  await _imageWriter.UploadImage(file).ConfigureAwait(false);
            return new UploadImageResponse() { Success = response.Success, Message = response.Response };
        }


        public void DeleteImage(DeleteImageRequest request)
        {
            string imageId = request.ImageID;
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), _env.WebRootPath, _tempImagefolder, imageId);
                File.Delete(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Delete request: {@ex} ", ex);

                //Logger.logInformation("Invalid Delete request: {@ex} ", ex)
            }

        }
    }
}
