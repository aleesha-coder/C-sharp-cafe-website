using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cafe_Website.Controllers
{
    [Route("[controller]")]
    public class RewardsController : Controller
    {
        // simulated rewards data

        public IActionResult Index()
        {
            // user rewards
            var userRewards = new
            {
                Points = 255,
                Level = "Silver",
                RewardsAvailable = new List<string>
                {
                    "1 Free Coffee",
                    "10% Off Sandwich",
                    "1 Free Dessert on Birthday"
                },
                ProgressToNextLevel = 75 // value = percentage
            };

             return View(userRewards);
        }
        

        public IActionResult Redeem(string reward)
        {
            // redeeming rewards
            ViewBag.RedeemedReward = reward;
            return View();
        }

        private readonly ILogger<RewardsController> _logger;

        public RewardsController(ILogger<RewardsController> logger)
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