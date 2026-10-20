using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Cafe_Website.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cafe_Website.Controllers
{
    //[Route("[controller]")]
    public class OrderController : Controller
    {

        private List<Order> _orders = new List<Order>();
        private List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Espresso", Price = 3.50m, Category = "HotDrink" },
            new Product { Id = 1, Name = "Cappuccino", Price = 4.50m, Category = "HotDrink" },
            new Product { Id = 1, Name = "Iced Coffee", Price = 4.50m, Category = "ColdDrink" },
            new Product { Id = 1, Name = "Chocolate Cake", Price = 5.50m, Category = "Dessert" },
            new Product { Id = 1, Name = "Sandwich", Price = 6.50m, Category = "SavoryFood" }
        };


        // cart
        public IActionResult Cart()
        {
            
            var cartJson = HttpContext.Session.GetString("Cart");
            var cart = string.IsNullOrEmpty(cartJson) ? new List<OrderItem>() : JsonSerializer.Deserialize<List<OrderItem>>(cartJson);
            return View(cart);
        }

         [HttpPost]
        public IActionResult AddToCart(int productId, int quantity = 1)
        {
            var product = _products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                var cartJson = HttpContext.Session.GetString("Cart");
                var cart = string.IsNullOrEmpty(cartJson) ? new List<OrderItem>() : JsonSerializer.Deserialize<List<OrderItem>>(cartJson);
                 var existingItem = cart.FirstOrDefault(i => i.ProductId == productId);
                if (existingItem != null)
                {
                    existingItem.Quantity += quantity;
                }
                else
                {
                    cart.Add(new OrderItem
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        UnitPrice = product.Price
                    });
                }
                  HttpContext.Session.SetString("Cart", JsonSerializer.Serialize(cart));
            }
            
            return RedirectToAction("Cart");
        }

        // checkout


         public IActionResult Checkout()
        {
            return View();
        }

         [HttpPost]
        public IActionResult PlaceOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                // Process order
                order.Id = _orders.Count + 1;
                _orders.Add(order);
                
                // Clear cart
                HttpContext.Session.Remove("Cart");
                
                return RedirectToAction("OrderConfirmation", new { id = order.Id });
            }
            return View("Checkout", order);
        }

         public IActionResult OrderConfirmation(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            return View(order);
        }

        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
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