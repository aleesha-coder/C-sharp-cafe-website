using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cafe_Website.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress] // checking for the valid email format
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)] // indicating field is a password
        public string? Password { get; set; }

        [Display(Name = "Full Name")] // display name (customisable)
        public string? FullName { get; set; }

        [Phone] // checks for valid phone number format
        public string? PhoneNumber { get; set; }

        public int RewardPoints { get; set; } = 0; // tracks reward points for user

        public DateTime MemberSince { get; set; } = DateTime.Now; // tracks when user joined

    }
}