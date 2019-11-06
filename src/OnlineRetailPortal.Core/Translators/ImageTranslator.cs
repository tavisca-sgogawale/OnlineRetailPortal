using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Core
{
    public static class ImageTranslator
    {
        public static Contracts.Image ToEntity(this Image image)
        {
            if (image == null)
                return null;
            return new Contracts.Image()
            {
                Url = image.Url
            };
        }

        public static Image ToModel(this Contracts.Image image)
        {
            if (image == null)
                return null;
            return new Image()
            {
                Url = image.Url
            };
        }
    }

}
