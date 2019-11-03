using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Contracts.Contracts;
using OnlineRetailPortal.Web.Models;

namespace OnlineRetailPortal.Web
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ICategoryResponse> GetCategories()
        {
            try {

                var serviceResponse = await _categoryService.GetCategoriesAsync();

                var response = serviceResponse.ToCategoriesContract();

                return response;

            }
            catch(Exception exception)
            {
                CategoryFailResponse respone = new CategoryFailResponse();
                respone.Message = exception.Message;
                respone.Status = 500;

                return respone; 
            }
           
        }
    }
}