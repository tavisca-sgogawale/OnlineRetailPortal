using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Mock
{
    public static class ImageTranslator
    {
        public static Image ToModel(this Image image)
        {
            return new Image()
            {
                Url = image.Url
            };
        }

        public static Image ToEntity(this Image image)
        {
            return new Image()
            {
                Url = image.Url
            };
        }
    }
}
