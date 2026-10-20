using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Cafe_Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cafe_Website.Controllers
{
    //[Route("[controller]")]
    public class AccountController : Controller
    {
        // simulated user data
         private static List<User> _users = new List<User>
        {
            new User { Id = 1, Email = "test@cafe.com", Password = "password123", FullName = "Test User", RewardPoints = 100 }
        };

        private readonly ILogger<AccountController> _logger;

        // login

         public IActionResult Login()
        {
            return View();
        }

         [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                
                TempData["UserId"] = user.Id;
                TempData["UserName"] = user.FullName;
                return RedirectToAction("Home", "Home");
            }
            
            ViewBag.Error = "Invalid email or password";
            return View();
        }

        //register

         public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = _users.Count + 1;
                _users.Add(user);
                TempData["Success"] = "Registration successful! Please login.";
                return RedirectToAction("Login");
            }
            return View(user);
        }

        //logout

        public IActionResult Logout()
        {
            TempData.Remove("UserId");
            TempData.Remove("UserName");
            return RedirectToAction("Index", "Home");
        }



        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}