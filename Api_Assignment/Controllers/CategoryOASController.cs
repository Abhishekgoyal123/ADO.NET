using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api_Assignment.Models;
using System.Net.Mime;

namespace Api_Assignment.Controllers
{

    [Route("api/[controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class CategoryOASController : ControllerBase
    {
        IDbAccessService<Category, int> catDbAccess;
        IDbAccessService<Product, int> prdService;
        //IDbAccessService<SubCategory, int> subcategoryService;
        eShoppingCodiContext context = new eShoppingCodiContext();

        public CategoryOASController(IDbAccessService<Category, int> catDbAccess, IDbAccessService<Product, int> prdService)
        {
            this.catDbAccess = catDbAccess;
            this.prdService = prdService;
            //this.subcategoryService = subcategoryService;
        }

        //public async Task<IEnumerable<Category>> Get()
        //{
        //    var result = await catDbAccess.GetAsync();
        //    return result;
        //}

        [HttpGet("/getcategoties")]
        public async Task<IEnumerable<Category>> Get()
        {
            var result = await catDbAccess.GetAsync();
            return result;
        }

        [HttpGet("/searchProduct")]

        public async Task<IEnumerable<Product>> SearchProduct(string CategoryName)
        {
            var result = (from product in context.Products
                          join subcategory in context.SubCategories on product.SubCategoryId equals subcategory.SubCategoryId
                          join category in context.Categories on subcategory.CategoryId equals category.CategoryId
                          where category.CategoryName == CategoryName
                          select product).ToList();
            
            return result;
        }

    }
}
