using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRetailPortal.Core
{
    public static class ImagesTranslator
    {
        public static List<Contracts.Image> ToEntity(this List<Image> images)
        {
            if (images == null)
                return null;
            return new Contracts.Product().Images = images.Select(x => new Contracts.Image
            {
                Url = x.Url
            }).ToList();
        }

        public static List<Image> ToModel(this List<Contracts.Image> images)
        {
            if (images == null)
                return null;
            return images.Select(x => new Image
            {
                Url = x.Url
            }).ToList();
        }
    }
}
