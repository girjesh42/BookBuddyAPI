using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookBuddyAPI.Models
{
    public partial class Users
    {
        public Users()
        {
            Cart = new HashSet<Cart>();
            Order = new HashSet<Order>();
            Payment = new HashSet<Payment>();
            Products = new HashSet<Products>();
            UserLoginAttemptHistory = new HashSet<UserLoginAttemptHistory>();
            UsersAddress = new HashSet<UsersAddress>();
        }

        public int UserId { get; set; }
        public string UserFname { get; set; }
        public string UserMname { get; set; }
        public string UserLname { get; set; }
        public string UserMobile { get; set; }
        public string UserEmail { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsVendor { get; set; }
        public string UserIntro { get; set; }
        public string UserProfile { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string PasswordHash { get; set; }
        public bool? LockedOut { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual ICollection<Products> Products { get; set; }
        public virtual ICollection<UserLoginAttemptHistory> UserLoginAttemptHistory { get; set; }
        public virtual ICollection<UsersAddress> UsersAddress { get; set; }
    }
}
