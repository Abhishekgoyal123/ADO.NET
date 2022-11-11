using Microsoft.AspNetCore.Mvc;

namespace MVC_2.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
