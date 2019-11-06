using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRetailPortal.Mock
{
    public static class ImagesTranslator
    {
        public static List<Image> ToModel(this List<Image> images)
        {
            if (images == null)
                return null;
            return new Product().Images = images.Select(x => new Image
            {
                Url = x.Url
            }).ToList();
        }

        public static List<Image> ToEntity(this List<Image> images)
        {
            if (images == null)
                return null;
            return new Product().Images = images.Select(x => new Image
            {
                Url = x.Url
            }).ToList();
        }
    }
}
