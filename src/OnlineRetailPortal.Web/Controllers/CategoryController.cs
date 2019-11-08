using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineRetailPortal.Contracts;


namespace OnlineRetailPortal.Web
{
    [Route("api")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("category")]
        public async Task<CategoryResponse> GetCategories()
        {

            try {

              var  serviceResponse = await _categoryService.GetCategoriesAsync();
                 return serviceResponse.ToCategoriesContract();
            }
            catch(Exception )
            {
                //Log(exception.Message, exception.trace);
                throw new BaseException(500,"Internal Server Error", null,System.Net.HttpStatusCode.NotFound);
                
   
            }
           

        }
    }
}