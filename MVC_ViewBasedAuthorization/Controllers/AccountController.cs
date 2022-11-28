using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using MVC_ViewBasedAuthorization.Models;

namespace MVC_ViewBasedAuthorization.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Login(Users user)
        {
            var usrs = new Users();
            // Read Password, Role and DateOfBirth
            var result = usrs.GetUsers().FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (result != null) // Check DB value
            {
                var userClaims = new List<Claim>()
                {
                        new Claim(ClaimTypes.Name, result.Username),
                        new Claim(ClaimTypes.Role, result.Role),
                        new Claim(ClaimTypes.DateOfBirth, result.DateOfBirth.ToString()),
                };

                var identity =new ClaimsIdentity
            }
}