using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Mock;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Services
{
   public class ProductService : IProductService
    {
        private readonly IProductStoreFactory _productStoreFactory; // factory or logic to resolve the product store will be handled later 
        private IProductStore _productStore = null;
        private IImageService _imageService;
        public ProductService(IProductStoreFactory productStoreFactory, IImageService imageService)
        {
            _productStoreFactory = productStoreFactory;
            _productStore = _productStoreFactory.GetProductStore("Mock");
            _imageService = imageService;
        }
        public async Task<AddProductResponse> AddProductAsync(AddProductRequest addProductRequest)
        {
            addProductRequest.HeroImage = _imageService.MoveToStorage(addProductRequest.HeroImage);
            addProductRequest.Images = _imageService.MoveToStorage(addProductRequest.Images);

            Core.Product product = addProductRequest.ToEntity();
            Core.Product response = await product.SaveAsync(_productStore);
            return AddProductTranslator.ToModel(response);
        }

        public async Task<GetProductServiceResponse>  GetProductAsync(string productId)
        {
            var response = await Core.Product.GetAsync(productId, _productStore);
            return GetProductServiceResponseTranslator.ToModel(response);
        }

        public async Task<GetProductsServiceResponse> GetProductsAsync(GetProductsServiceRequest getProductsServiceRequest)
        {
            var response = await Core.Product.GetProductsAsync(getProductsServiceRequest, _productStore);
            return response.ToModel();
        }


    }
}
