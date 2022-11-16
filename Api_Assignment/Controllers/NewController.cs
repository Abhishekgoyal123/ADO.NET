using Microsoft.AspNetCore.Mvc;
using Api_Assignment.Models;
using System.Collections.Generic;

namespace Api_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class NewController : Controller
    {
       
        eShoppingCodiContext context;

        public NewController(eShoppingCodiContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IEnumerable<Product> Index(string SubCategoryName, int noOfRecords)
        {
            IEnumerable<Product> a;
            List<Product> productList = new List<Product>();
            productList = (from prod in context.Products
                           join subcat in context.SubCategories on prod.SubCategoryId equals subcat.SubCategoryId
                           join cat in context.Categories on subcat.CategoryId equals cat.CategoryId
                           where subcat.SubCategoryName == SubCategoryName

                           select prod).ToList();

            int abc = productList.Count();

            if(abc > noOfRecords)
            {
                 a = productList.Take(noOfRecords).Skip(abc - noOfRecords);
            }
            else
            {
                 a = productList.Take(abc);
            }
            return a;

        }
    }
}
