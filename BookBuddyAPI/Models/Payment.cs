using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookBuddyAPI.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public string TransectionId { get; set; }
        public string PaymentType { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Order Order { get; set; }
        public virtual Users User { get; set; }
    }
}
