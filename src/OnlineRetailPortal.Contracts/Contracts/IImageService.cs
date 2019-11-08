using Microsoft.AspNetCore.Http;
using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Contracts
{
    public interface IImageService
    {
        /// <summary>
        /// Takes an UploadImageRequest type object and tries to save the image in it
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UploadImageResponse> UploadImageAsync(UploadImageRequest request);

        /// <summary>
        /// Takes a DeleteImageRequest object containing the name of the file to delete from the temporary folder
        /// </summary>
        /// <param name="request"></param>
        void DeleteTempImage(DeleteImageRequest request);
    }
    
}
