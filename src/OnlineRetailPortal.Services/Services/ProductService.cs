using OnlineRetailPortal.Contracts;
using System;
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
            _productStore = _productStoreFactory.GetProductStore();
            _imageService = imageService;
        }

        public async Task<AddProductResponse> AddProductAsync(AddProductRequest addProductRequest)
        {
            var config = new ProductConfiguration()
            {
                ExpiryInDays = 30
            };
 
            addProductRequest.HeroImage = _imageService.MoveToStorage(addProductRequest.HeroImage);
            addProductRequest.Images = _imageService.MoveToStorage(addProductRequest.Images);

            Core.Product product = addProductRequest.ToEntity();
            Core.Product response = await product.SaveAsync(_productStore, config);
            return response.ToModel();
        }

        public Task<GetProductServiceResponse> GetProductAsync(string productId)
        {
            throw new NotImplementedException();
        }

        public async Task<GetProductsServiceResponse> GetProductsAsync(GetProductsServiceRequest request)
        {
            var response = await Core.Product.GetProductsAsync(request, _productStore);
            return response.ToModel();
        }
    }
}
