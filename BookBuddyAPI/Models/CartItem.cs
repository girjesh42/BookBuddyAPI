using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookBuddyAPI.Models
{
    public partial class CartItem
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public double Price { get; set; }
        public DateTime? PriceExpiresAt { get; set; }
        public double Discount { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Products Product { get; set; }
    }
}
