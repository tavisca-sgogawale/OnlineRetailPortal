using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Core
{
    public static class UpdateProductTranslator
    {
        public static ProductEntity ToStoreEntity(this Product updateProduct)
        {
            var updateProductStoreRequest = new ProductEntity()
            {
                Id = updateProduct.Id,
                Name = updateProduct.Name,
                Description = updateProduct.Description,
                HeroImage = updateProduct.HeroImage,
                Price = updateProduct.Price.ToEntity(),
                Category = updateProduct.Category.ToEntity(),
                Images = updateProduct.Images,
                PurchasedDate = updateProduct.PurchasedDate,
                PickupAddress = updateProduct.PickupAddress.ToEntity(),
                PostDateTime = updateProduct.PostDateTime,
                ExpirationDate = updateProduct.ExpirationDate,
                Status = updateProduct.Status.ToEntity()
            };

            return updateProductStoreRequest;
        }
        public static ProductEntity GetUpdatedProduct(this ProductEntity productEntity,ProductEntity getResult)
        {

            if (getResult != null)
            {
                getResult.Name = productEntity.Name ?? getResult.Name;
                getResult.Description = productEntity.Description ?? getResult.Description;
                getResult.Category.Name = productEntity.Category.Name ?? getResult.Category.Name;



                getResult.Images = (productEntity.Images != null) ?
                                                    productEntity.Images : getResult.Images;
                getResult.Price.Money.Amount = (productEntity.Price != null) ?
                                                    (productEntity.Price.Money != null) ?
                                                        productEntity.Price.Money.Amount : getResult.Price.Money.Amount
                                            : getResult.Price.Money.Amount;
                getResult.Price.IsNegotiable = (productEntity.Price != null) ?
                                                    (productEntity.Price.IsNegotiable != null) ?
                                                            Convert.ToBoolean(productEntity.Price.IsNegotiable) : getResult.Price.IsNegotiable
                                                : getResult.Price.IsNegotiable;
                getResult.HeroImage = (productEntity.HeroImage != null) ?
                                                        productEntity.HeroImage : getResult.HeroImage;
                getResult.PurchasedDate = productEntity.PurchasedDate ?? getResult.PurchasedDate;

                if (productEntity.PickupAddress != null)
                {
                    if (ValidatePickupAddress(getResult))
                    {
                        getResult.PickupAddress.Line1 = productEntity.PickupAddress.Line1 ?? getResult.PickupAddress.Line1;
                        getResult.PickupAddress.Line2 = productEntity.PickupAddress.Line2 ?? getResult.PickupAddress.Line2;
                        getResult.PickupAddress.State = productEntity.PickupAddress.State ?? getResult.PickupAddress.State;
                        getResult.PickupAddress.City = productEntity.PickupAddress.City ?? getResult.PickupAddress.City;
                        getResult.PickupAddress.Pincode = (productEntity.PickupAddress.Pincode != 0) ?
                                                                productEntity.PickupAddress.Pincode : getResult.PickupAddress.Pincode;
                    }
                    else
                    {
                        if (ValidatePickupAddress(productEntity))
                        {
                            getResult.PickupAddress.Line1 = productEntity.PickupAddress.Line1;
                            getResult.PickupAddress.Line2 = productEntity.PickupAddress.Line2;
                            getResult.PickupAddress.State = productEntity.PickupAddress.State;
                            getResult.PickupAddress.City = productEntity.PickupAddress.City;
                            getResult.PickupAddress.Pincode = productEntity.PickupAddress.Pincode;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                if ((getResult.Status.ToString() == "Sold" || getResult.Status.ToString() == "Deleted") && productEntity.Status.ToString() == "Active") { }
                else
                {
                    getResult.Status = productEntity.Status;
                }
            }
            return getResult;

        }
        public static bool ValidatePickupAddress(ProductEntity productEntity)
        {
            if (productEntity.PickupAddress.Line1 != null && productEntity.PickupAddress.City != null && productEntity.PickupAddress.State != null && productEntity.PickupAddress.Pincode > 0)
            {
                return true;
            }
            return false;
        }
        public static Product ToStoreModel(this ProductEntity addProductStoreResponse)
        {
            if (addProductStoreResponse == null)
                return null;
            var product = new Product(addProductStoreResponse.Price.ToModel(), addProductStoreResponse.SellerId, addProductStoreResponse.Name)
            {
                Id = addProductStoreResponse.Id,
                Description = addProductStoreResponse.Description,
                HeroImage = addProductStoreResponse.HeroImage,
                Category = addProductStoreResponse.Category.ToModel(),
                Status = addProductStoreResponse.Status.ToModel(),
                PostDateTime = addProductStoreResponse.PostDateTime,
                ExpirationDate = addProductStoreResponse.ExpirationDate,
                Images = addProductStoreResponse.Images,
                PurchasedDate = addProductStoreResponse.PurchasedDate,
                PickupAddress = addProductStoreResponse.PickupAddress.ToModel()
            };

            return product;
        }
    }
}
