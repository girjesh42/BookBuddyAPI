using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookBuddyAPI.Models
{
    public partial class Cart
    {
        public Cart()
        {
            CartItem = new HashSet<CartItem>();
        }

        public int CartId { get; set; }
        public int UserId { get; set; }
        public string SessionId { get; set; }
        public string TokenId { get; set; }
        public string CartStatus { get; set; }
        public int AddressId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual UsersAddress Address { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<CartItem> CartItem { get; set; }
    }
}
