using Microsoft.AspNetCore.Mvc;

namespace MVC_1.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
