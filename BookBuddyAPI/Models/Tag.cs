using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookBuddyAPI.Models
{
    public partial class Tag
    {
        public Tag()
        {
            ProductTag = new HashSet<ProductTag>();
        }

        public int TagId { get; set; }
        public string TagTitle { get; set; }
        public string MetaTitle { get; set; }

        public virtual ICollection<ProductTag> ProductTag { get; set; }
    }
}
