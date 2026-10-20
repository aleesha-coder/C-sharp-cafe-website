using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cafe_Website.Controllers
{
    //[Route("[controller]")]
    public class SettingsController : Controller
    {

        // simulated settings page

         public IActionResult Index()
        {
            
            var settings = new
            {
                Notifications = true,
                Theme = "Light",
                Language = "English",
                AutoLogin = false
            };
            
            return View(settings);
        }

        [HttpPost]
        public IActionResult UpdateSettings(bool notifications, string theme, string language, bool autoLogin)
        {
            // Save settings logic
            TempData["Message"] = "Settings updated successfully!";
            return RedirectToAction("Index");
        }


        private readonly ILogger<SettingsController> _logger;

        public SettingsController(ILogger<SettingsController> logger)
        {
            _logger = logger;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}