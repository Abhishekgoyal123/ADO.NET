using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api_Assignment.Models;

namespace Api_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Search : ControllerBase
    {
       
        public void abcd()
        {
            eShoppingCodiContext context = new eShoppingCodiContext();

            var abc = from cat in context.Categories
                      join 
        }
    }
}
