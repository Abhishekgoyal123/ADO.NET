using Api_Northwind.Models;
using Api_Northwind.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Api_Northwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NorthwindCacheController : ControllerBase
    {
        string a = "sd";
        string b = "dsd";
        string c = a + b;
        IMemoryCache memoryCache;
        IService<Customer> catservice;
        NorthwindContext context;
        private string cacheKey = "Shippers";

        public NorthwindCacheController(IMemoryCache memoryCache, IService<Customer> catservice, NorthwindContext context)
        {
            this.context = context;
            this.memoryCache = memoryCache;
            this.catservice = catservice;
        }

        [HttpGet]

        public async Task<ResponseObject> GetAsync()
        {
            ResponseObject response = new ResponseObject();
            List<CustomersEmployeesShipper> customerList = null;
            try
            {
                var isDataAvailableInCache = memoryCache.TryGetValue(cacheKey, out customerList);

                if (!isDataAvailableInCache)
                {
                    customerList = context.CustomersEmployeesShippers.ToList();
                    response.CustomersEmployeesShipper = customerList;
                    response.Message = "Data is received from Database";

                    var memoryCacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(30)).SetAbsoluteExpiration(TimeSpan.FromMinutes(1));
                    memoryCache.Set(cacheKey, customerList, memoryCacheOptions);
                }
                else
                {
                    response.CustomersEmployeesShipper = customerList;
                    response.Message = "Data is received from cache";
                }

                return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}
