using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookBuddyAPI.Models
{
    public partial class ProductTag
    {
        public int ProductTagId { get; set; }
        public int? ProductId { get; set; }
        public int? TagId { get; set; }

        public virtual Products Product { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
