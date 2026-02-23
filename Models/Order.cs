using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cafe_Website.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        
        [DataType(DataType.Currency)]
        public decimal TotalAmount { get; set; }
        
        public string Status { get; set; } = "Pending"; // status of order = Pending, Preparing or Ready, default = pending
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }

     public class OrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string? SpecialInstructions { get; set; }
    }
}