using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using OnlineRetailPortal.Contracts;
using System;
using System.IO;
using System.Threading.Tasks;
using OnlineRetailPortal.Services.Translators;
using System.Collections.Generic;

namespace OnlineRetailPortal.Services.Services
{
    public class ImageService : IImageService
    {
        private readonly ImageWriter _imageWriter;
        private IHostingEnvironment _env;
        private string _tempImageFolder;
        private string _storageFolder;

        public ImageService(IHostingEnvironment env, IConfiguration iconfig)
        {
            _imageWriter = new ImageWriter(iconfig, env);
            _env = env;
            _tempImageFolder = iconfig.GetSection("TempImageFolder").Value;
            _storageFolder = iconfig.GetSection("PermanentImageFolder").Value;
        }

        /// <summary>
        /// Takes an UploadImageRequest type object and tries to save the image in it
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UploadImageResponse> UploadImageAsync(UploadImageRequest request)
        {
            IFormFile file = request.File;
            ImageWriterResponse response = await _imageWriter.WriteFile(file);
            return response.ToModel();
        }

        /// <summary>
        /// Takes an imageID inside a DeleteImageRequest Object and deletes the image from the temporary Storage
        /// </summary>
        /// <param name="request"></param>
        public void DeleteImage(DeleteImageRequest request)
        {
            string imageId = request.ImageId;
            string imageFolder = GetImageFolder(imageId);
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), _env.WebRootPath, imageFolder, imageId);
                File.Delete(path);
            }
            catch (Exception ex)
            {
                //Logger.logInformation("Invalid Delete request: {@ex} ", ex)
                throw new BaseException(StatusCodes.Status500InternalServerError, "Internal Server Error", null, System.Net.HttpStatusCode.InternalServerError);
            }

        }

        /// <summary>
        /// Moves the images provided as string URLs from temporary to permanent
        /// </summary>
        /// <param name="tempImageUrls"></param>
        /// <returns></returns>
        public List<string> MoveToStorage(List<string> tempImageUrls)
        {
            if (tempImageUrls == null)
                return null;

            List<string> imageUrls = new List<string>();
            string tempPath = Path.Combine(Directory.GetCurrentDirectory(), _env.WebRootPath, _tempImageFolder);
            string storagePath = Path.Combine(Directory.GetCurrentDirectory(), _env.WebRootPath, _storageFolder);
            
            try
            {
                foreach (string imageUrl in tempImageUrls)
                {
                    if (!imageUrl.StartsWith("tmp_"))
                        throw new System.IO.FileNotFoundException(message:"The FileName didnt start with \"tmp_\". Is not a valid Image.") ;

                    var imageName = imageUrl.Split("tmp_")[1];
                    File.Move(Path.Combine(tempPath, imageUrl), Path.Combine(storagePath, imageName));
                    imageUrls.Add(Path.Combine(storagePath, imageName));
                }
                return imageUrls;
            }
            catch (System.IO.FileNotFoundException exf)
            {
                //Logger.logInformation("Invalid Move request: {@ex} ", ex)
                throw new BaseException(StatusCodes.Status404NotFound, "The Image corresponding to the product was not found", null, System.Net.HttpStatusCode.NotFound);

            }
            catch (Exception ex)
            {
                //Logger.logInformation("Invalid Delete request: {@ex} ", ex)
                throw new BaseException(StatusCodes.Status500InternalServerError, "Internal Server Error", null, System.Net.HttpStatusCode.InternalServerError);
            }
        }
        /// <summary>
        /// Moves the image provided as a string URL from temporary to permanent
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public string MoveToStorage(string image)
        {
            string storedImage;
            string tempPath = Path.Combine(Directory.GetCurrentDirectory(), _env.WebRootPath, _tempImageFolder);
            string storagePath = Path.Combine(Directory.GetCurrentDirectory(), _env.WebRootPath, _storageFolder);

            try
            {
                if (!image.StartsWith("tmp_"))
                    throw new System.IO.FileNotFoundException(message: "The FileName didnt start with \"tmp_\". Is not a valid Image.");

                var img = image.Split("tmp_")[1];
                File.Move(Path.Combine(tempPath, image), Path.Combine(storagePath, img));
                storedImage = Path.Combine(storagePath, img);
                return storedImage;
            }
            catch (System.IO.FileNotFoundException ex)
            {
                //Logger.logInformation("Invalid Move request: {@ex} ", ex)
                throw new BaseException(StatusCodes.Status404NotFound, "The Hero image corresponding to the product was not found", null, System.Net.HttpStatusCode.NotFound);

            }
            catch (Exception ex)
            {
                //Logger.logInformation("Invalid Move request: {@ex} ", ex)
                throw new BaseException(StatusCodes.Status500InternalServerError, "Internal Server Error", null, System.Net.HttpStatusCode.InternalServerError);
            }
        }

        private string GetImageFolder(string imageId)
        {
            if (imageId.StartsWith("tmp_"))
                return _tempImageFolder;
            else
                return _storageFolder;
        }

    }
}