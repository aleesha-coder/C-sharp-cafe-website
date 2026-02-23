using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafe_Website.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; } // options of products (drinks, food or desserts)
        public string? ImageUrl { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}