using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookBuddyAPI.Models
{
    public partial class Products
    {
        public Products()
        {
            CartItem = new HashSet<CartItem>();
            OrderItem = new HashSet<OrderItem>();
            ProductCategory = new HashSet<ProductCategory>();
            ProductReview = new HashSet<ProductReview>();
            ProductTag = new HashSet<ProductTag>();
        }

        public int ProductId { get; set; }
        public int? VendorId { get; set; }
        public string ProductName { get; set; }
        public string MetaTitle { get; set; }
        public string ProductSummery { get; set; }
        public string ProductDescription { get; set; }
        public string ProductType { get; set; }
        public string Sku { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime PublishedAt { get; set; }
        public DateTime? StartsAt { get; set; }
        public DateTime? EndsAt { get; set; }
        public string ProductPic { get; set; }

        public virtual Users Vendor { get; set; }
        public virtual ICollection<CartItem> CartItem { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
        public virtual ICollection<ProductCategory> ProductCategory { get; set; }
        public virtual ICollection<ProductReview> ProductReview { get; set; }
        public virtual ICollection<ProductTag> ProductTag { get; set; }
    }
}
