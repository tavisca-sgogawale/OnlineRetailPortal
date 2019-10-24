﻿using Microsoft.AspNetCore.Http;
using OnlineRetailPortal.Contracts.Contracts;
using OnlineRetailPortal.Contracts.Models;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Services.Services
{
    public class ImageWriter : IImageWriter
    {
        public async Task<IImageWriterResponse> UploadImage(IFormFile file)
        {
            if (file != null && CheckIfImageFile(file))
            {
                return await WriteFile(file).ConfigureAwait(false);
            }

            return new ImageWriterFailResponse() { Success = false, Response = "Invalid image file" };
        }

        /// <summary>
        /// Method to check if file is image file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool CheckIfImageFile(IFormFile file)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            return WriterHelper.GetImageFormat(fileBytes) != WriterHelper.ImageFormat.unknown;
        }

        /// <summary>
        /// Method to write file onto the disk
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<IImageWriterResponse> WriteFile(IFormFile file)
        {
            string fileName;
            string path;
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = Guid.NewGuid().ToString() + extension; //Create a new Name 
                                                                  //for the file due to security reasons.
                path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\tempImages", fileName);

                using (var bits = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(bits).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                return new ImageWriterFailResponse() { Success=false, Response = e.Message}; 
            }

            return new ImageWriterSuccessResponse(){ Success=true, Response = "tempImages/" + fileName};
        }
    }
}