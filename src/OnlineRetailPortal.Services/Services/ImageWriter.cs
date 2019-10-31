using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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
        private IHostingEnvironment _env;
        private string _tempImagefolder;
        public ImageWriter(IConfiguration iconfig, IHostingEnvironment env)
        {
            _env = env;
            _tempImagefolder = iconfig.GetSection("TempImageFolder").Value;
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
                path = Path.Combine(Directory.GetCurrentDirectory(), _env.WebRootPath, _tempImagefolder, fileName);

                using (var bits = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(bits).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                return new ImageWriterFailResponse() { Code= StatusCodes.Status500InternalServerError, Response = e.Message}; 
            }

            return new ImageWriterSuccessResponse(){ Code= StatusCodes.Status200OK, Response = _tempImagefolder+ "/" + fileName};
        }
    }
}
