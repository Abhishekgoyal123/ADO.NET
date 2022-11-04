using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api_Northwind.Service;
using Api_Northwind.Models;

namespace Api_Northwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Northwind_controller :  ControllerBase
    {
        IService<Customer> catservice;

        public Northwind_controller(IService<Customer> catservice)
        {
            this.catservice = catservice;
        }

        [HttpGet]
        public async Task<IActionResult> Search(string productName)
        {
            var abc1 = catservice.Search1(productName);
            return Ok(abc1);
        }
    }
}
