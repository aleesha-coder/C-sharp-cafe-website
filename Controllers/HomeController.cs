using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cafe_Website.Models;

namespace Cafe_Website.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
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


    // simulated data 
    // database used in future iterations

     private List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Espresso", Description = "Strong coffee", Price = 3.50m, Category = "HotDrink" },
            new Product { Id = 2, Name = "Cappuccino", Description = "Coffee with milk foam", Price = 4.50m, Category = "HotDrink" },
            new Product { Id = 3, Name = "Iced Coffee", Description = "Chilled coffee", Price = 4.00m, Category = "ColdDrink" },
            new Product { Id = 4, Name = "Chocolate Cake", Description = "Rich chocolate cake", Price = 5.50m, Category = "Dessert" },
            new Product { Id = 5, Name = "Sandwich", Description = "Chicken Mayo sandwich", Price = 6.50m, Category = "Savory Food" }
        };

         public IActionResult Index() 
    {
        return View();
    }

    public IActionResult Home()
        {
            return View(); // main home screen 
        }

        public IActionResult Drinks()
        {
            var drinks = _products.Where(p => p.Category.Contains("Drink")).ToList();
            return View(drinks);
        }

        public IActionResult HotDrinks()
        {
            var hotDrinks = _products.Where(p => p.Category == "HotDrink").ToList();
            return View(hotDrinks);
        }

        public IActionResult ColdDrinks()
        {
            var coldDrinks = _products.Where(p => p.Category == "ColdDrink").ToList();
            return View(coldDrinks);
        }

        public IActionResult Desserts()
        {
            var desserts = _products.Where(p => p.Category == "Dessert").ToList();
            return View(desserts);
        }

        public IActionResult SavoryFoods()
        {
            var foods = _products.Where(p => p.Category == "SavoryFood").ToList();
            return View(foods);
        }


}
