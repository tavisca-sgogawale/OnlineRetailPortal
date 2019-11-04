﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using OnlineRetailPortal.Contracts.Contracts;
using System;
using System.IO;
using System.Threading.Tasks;
using OnlineRetailPortal.Services.Translators;
using OnlineRetailPortal.Contracts.Models;

namespace OnlineRetailPortal.Services.Services
{
    public class ImageHandler : IImageHandler
    {
        private readonly ImageWriter _imageWriter;
        private IHostingEnvironment _env;
        private string _tempImagefolder;

        public ImageHandler(IHostingEnvironment env, IConfiguration iconfig)
        {
            _imageWriter = new ImageWriter(iconfig,env);
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
            ImageWriterResponse response =  await _imageWriter.WriteFile(file).ConfigureAwait(false);
            return response.ToUploadImageResponse();
        }

        /// <summary>
        /// Takes an imageID inside a DeleteImageRequest Object and deletes the image from the temporary Storage
        /// </summary>
        /// <param name="request"></param>
        public void DeleteTempImage(DeleteImageRequest request)
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
