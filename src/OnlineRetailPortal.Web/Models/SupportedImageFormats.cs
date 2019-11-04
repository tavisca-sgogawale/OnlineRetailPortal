using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web.Models
{
    public class SupportedImageFormats
    {
        public enum ImageFormat
        {
            bmp,
            jpeg,
            gif,
            tiff,
            png,
            unknown
        }
        /// <summary>
        /// Takes the file as a byte[] and returns the type of image, returns Unkown if other or unrecognized
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static ImageFormat GetImageFormat(byte[] bytes)
        {
            var bmp = Encoding.ASCII.GetBytes("BM");     // BMP
            var gif = Encoding.ASCII.GetBytes("GIF");    // GIF
            var png = new byte[] { 137, 80, 78, 71 };              // PNG
            var tif = new byte[] { 73, 73, 42 };                  // TIFF format for the older FAT systems
            var tiff = new byte[] { 77, 77, 42 };                 // TIFF format for the NTFS systems
            var jpeg = new byte[] { 255, 216, 255, 224 };          // jpeg
            var jpegCanon = new byte[] { 255, 216, 255, 225 };         // jpeg canon

            if (bmp.SequenceEqual(bytes.Take(bmp.Length)))
                return ImageFormat.bmp;

            if (gif.SequenceEqual(bytes.Take(gif.Length)))
                return ImageFormat.gif;

            if (png.SequenceEqual(bytes.Take(png.Length)))
                return ImageFormat.png;

            if (tif.SequenceEqual(bytes.Take(tif.Length)))
                return ImageFormat.tiff;

            if (tiff.SequenceEqual(bytes.Take(tiff.Length)))
                return ImageFormat.tiff;

            if (jpeg.SequenceEqual(bytes.Take(jpeg.Length)))
                return ImageFormat.jpeg;

            if (jpegCanon.SequenceEqual(bytes.Take(jpegCanon.Length)))
                return ImageFormat.jpeg;

            return ImageFormat.unknown;
        }
    }
}
