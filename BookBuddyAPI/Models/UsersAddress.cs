using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookBuddyAPI.Models
{
    public partial class UsersAddress
    {
        public UsersAddress()
        {
            Cart = new HashSet<Cart>();
            Order = new HashSet<Order>();
        }

        public int UserAddressId { get; set; }
        public int UserId { get; set; }
        public string UserCity { get; set; }
        public string UserState { get; set; }
        public int UserPostalCode { get; set; }
        public string UserCountry { get; set; }
        public string UserPhone1 { get; set; }
        public string UserPhone2 { get; set; }
        public string UserEmail1 { get; set; }
        public string UserEmail2 { get; set; }
        public string UserCo { get; set; }
        public string UserAddress1 { get; set; }
        public string UserAddress2 { get; set; }
        public string UserAddress3 { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
