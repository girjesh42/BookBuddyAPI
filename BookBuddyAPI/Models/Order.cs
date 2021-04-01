using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookBuddyAPI.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItem = new HashSet<OrderItem>();
            Payment = new HashSet<Payment>();
        }

        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string SessionId { get; set; }
        public string TokenId { get; set; }
        public string OrderStatus { get; set; }
        public double SubTotal { get; set; }
        public double ItemDiscount { get; set; }
        public double Tax { get; set; }
        public double ShippingCharges { get; set; }
        public double Total { get; set; }
        public string Promo { get; set; }
        public double PromoDiscount { get; set; }
        public double GrandTotal { get; set; }
        public int AddressId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual UsersAddress Address { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
