using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Core
{
    public static class UpdateProductTranslator
    {
        public static ProductEntity ToStoreEntity(this Product product)
        {
            var updateProductStoreRequest = new ProductEntity()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                HeroImage = product.HeroImage,
                Price = product.Price.ToEntity(),
                Category = product.Category.ToEntity(),
                Images = product.Images,
                PurchasedDate = product.PurchasedDate,
                PickupAddress = product.PickupAddress.ToEntity(),
                PostDateTime = product.PostDateTime,
                ExpirationDate = product.ExpirationDate,
                Status = product.Status.ToEntity()
            };

            return updateProductStoreRequest;
        }
        public static ProductEntity GetUpdatedProduct(this ProductEntity requestProductEntity,ProductEntity dbProductEntity)
        {
            dbProductEntity.Name = requestProductEntity.Name ?? dbProductEntity.Name;
            dbProductEntity.Description = requestProductEntity.Description ?? dbProductEntity.Description;
            dbProductEntity.Category.Name = requestProductEntity.Category.Name ?? dbProductEntity.Category.Name;
            dbProductEntity.Images = requestProductEntity.Images ?? dbProductEntity.Images;
            dbProductEntity.Price.Money.Amount = (requestProductEntity.Price != null) ?
                                                (requestProductEntity.Price.Money != null) ?
                                                    requestProductEntity.Price.Money.Amount : dbProductEntity.Price.Money.Amount
                                        : dbProductEntity.Price.Money.Amount;
            dbProductEntity.Price.IsNegotiable = (requestProductEntity.Price != null) ?
                                                (requestProductEntity.Price.IsNegotiable != null) ?
                                                        Convert.ToBoolean(requestProductEntity.Price.IsNegotiable) : dbProductEntity.Price.IsNegotiable
                                            : dbProductEntity.Price.IsNegotiable;
            dbProductEntity.HeroImage = requestProductEntity.HeroImage ?? dbProductEntity.HeroImage;
            dbProductEntity.PurchasedDate = requestProductEntity.PurchasedDate ?? dbProductEntity.PurchasedDate;

            if (requestProductEntity.PickupAddress != null)
            {
                if (dbProductEntity.PickupAddress == null) 
                    dbProductEntity.PickupAddress = new Contracts.Address();
                dbProductEntity.PickupAddress.Line1 = requestProductEntity.PickupAddress.Line1 ?? dbProductEntity.PickupAddress.Line1;
                dbProductEntity.PickupAddress.Line2 = requestProductEntity.PickupAddress.Line2 ?? dbProductEntity.PickupAddress.Line2;
                dbProductEntity.PickupAddress.State = requestProductEntity.PickupAddress.State ?? dbProductEntity.PickupAddress.State;
                dbProductEntity.PickupAddress.City = requestProductEntity.PickupAddress.City ?? dbProductEntity.PickupAddress.City;
                dbProductEntity.PickupAddress.Pincode = (requestProductEntity.PickupAddress.Pincode != 0) ?
                                                        requestProductEntity.PickupAddress.Pincode : dbProductEntity.PickupAddress.Pincode;
            }

            if (!(dbProductEntity.Status.ToString() == "Deleted" || dbProductEntity.Status.ToString() == "Sold") ) 
            { 
                dbProductEntity.Status = requestProductEntity.Status; 
            }

            return dbProductEntity;
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
