using Microsoft.AspNetCore.Mvc;
using MVC_Client.Models;
using System.Diagnostics;
using ClientNS;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        HttpClient client = null;
        string baseUrl = string.Empty;
        ClientProxy proxy = null;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            baseUrl = "https://localhost:7157";
            client = new HttpClient();
            proxy = new ClientProxy(baseUrl, client);
        }

        public async Task<IActionResult> Index()
        {
            //var x = TempData["CategoryId"];

            //var product = new Product();
            
            var result = (await proxy.GetcategotiesAsync()).ToList();

            //List<SelectListItem> categoryItem = new List<SelectListItem>();
            
            //foreach (var cat in categories)
            //{
            //    categoryItem.Add(new SelectListItem(cat.CategoryName, cat.CategoryId.ToString()));
            //}
            
            //ViewBag.Categories = categoryItem;


            //var result = await proxy.SearchProductAsync("Fashion");
            //ViewBag.Categories = JsonSerializer.Serialize(result);
            return View(result);
            
        }

        public async Task<IActionResult> Search()
        {
            var result = await proxy.SearchProductAsync("Fashion");
            ViewBag.Categories = JsonSerializer.Serialize(result);
            return View(result);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}