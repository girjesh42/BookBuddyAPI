using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookBuddyAPI.Models
{
    public partial class ProductReview
    {
        public ProductReview()
        {
            InversePerent = new HashSet<ProductReview>();
        }

        public int ProductReviewId { get; set; }
        public int? ProductId { get; set; }
        public int? PerentId { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewSummery { get; set; }
        public int Rating { get; set; }
        public bool IsPublished { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime PublishedAt { get; set; }

        public virtual ProductReview Perent { get; set; }
        public virtual Products Product { get; set; }
        public virtual ICollection<ProductReview> InversePerent { get; set; }
    }
}
