using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookBuddyAPI.Models
{
    public partial class BookBuddyContext : DbContext
    {
        public BookBuddyContext()
        {
        }

        public BookBuddyContext(DbContextOptions<BookBuddyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartItem> CartItem { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductReview> ProductReview { get; set; }
        public virtual DbSet<ProductTag> ProductTag { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<UserLoginAttemptHistory> UserLoginAttemptHistory { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersAddress> UsersAddress { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:bookbuddy1.database.windows.net,1433;Initial Catalog=BookBuddy;Persist Security Info=False;User ID=Admin360;Password=Admin@360;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.CartId)
                    .HasColumnName("cart_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.CartStatus)
                    .IsRequired()
                    .HasColumnName("cart_status")
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SessionId)
                    .IsRequired()
                    .HasColumnName("session_id")
                    .HasMaxLength(100);

                entity.Property(e => e.TokenId)
                    .IsRequired()
                    .HasColumnName("token_id")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart__address_id__07C12930");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart__userId__06CD04F7");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.Property(e => e.CartItemId)
                    .HasColumnName("cartItem_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.PriceExpiresAt)
                    .HasColumnName("price_expires_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartItem)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartItem__cart_i__0D7A0286");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartItem)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartItem__produc__0C85DE4D");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CategoryDescription)
                    .HasColumnName("category_description")
                    .HasMaxLength(200);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("category_name")
                    .HasMaxLength(100);

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK__Category__parent__6B24EA82");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order_");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GrandTotal).HasColumnName("grand_total");

                entity.Property(e => e.ItemDiscount).HasColumnName("item_discount");

                entity.Property(e => e.OrderStatus)
                    .IsRequired()
                    .HasColumnName("order_status")
                    .HasMaxLength(10);

                entity.Property(e => e.Promo)
                    .HasColumnName("promo")
                    .HasMaxLength(50);

                entity.Property(e => e.PromoDiscount).HasColumnName("promo_discount");

                entity.Property(e => e.SessionId)
                    .IsRequired()
                    .HasColumnName("session_id")
                    .HasMaxLength(100);

                entity.Property(e => e.ShippingCharges).HasColumnName("shipping_charges");

                entity.Property(e => e.SubTotal).HasColumnName("sub_total");

                entity.Property(e => e.Tax).HasColumnName("tax");

                entity.Property(e => e.TokenId)
                    .IsRequired()
                    .HasColumnName("token_id")
                    .HasMaxLength(100);

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order___address___14270015");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order___userId__123EB7A3");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.OrderItemId)
                    .HasColumnName("orderItem_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderItem__order__19DFD96B");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderItem__produ__18EBB532");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId)
                    .HasColumnName("payment_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.PaymentMode)
                    .IsRequired()
                    .HasColumnName("payment_mode")
                    .HasMaxLength(10);

                entity.Property(e => e.PaymentStatus)
                    .IsRequired()
                    .HasColumnName("payment_status")
                    .HasMaxLength(10);

                entity.Property(e => e.PaymentType)
                    .IsRequired()
                    .HasColumnName("payment_type")
                    .HasMaxLength(10);

                entity.Property(e => e.TransectionId)
                    .IsRequired()
                    .HasColumnName("transection_id")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Payment__order_i__1F98B2C1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Payment__userId__1EA48E88");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.Property(e => e.ProductCategoryId).HasColumnName("productCategory_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__ProductCa__categ__7D439ABD");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCategory)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ProductCa__produ__7C4F7684");
            });

            modelBuilder.Entity<ProductReview>(entity =>
            {
                entity.Property(e => e.ProductReviewId).HasColumnName("productReview_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsPublished).HasColumnName("is_published");

                entity.Property(e => e.PerentId).HasColumnName("perent_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.PublishedAt)
                    .HasColumnName("published_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.ReviewSummery)
                    .HasColumnName("review_summery")
                    .HasMaxLength(250);

                entity.Property(e => e.ReviewTitle)
                    .HasColumnName("review_title")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Perent)
                    .WithMany(p => p.InversePerent)
                    .HasForeignKey(d => d.PerentId)
                    .HasConstraintName("FK__ProductRe__peren__01142BA1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductReview)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ProductRe__produ__00200768");
            });

            modelBuilder.Entity<ProductTag>(entity =>
            {
                entity.Property(e => e.ProductTagId).HasColumnName("productTag_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.TagId).HasColumnName("tag_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductTag)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ProductTa__produ__787EE5A0");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.ProductTag)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("FK__ProductTa__tag_i__797309D9");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Products__47027DF5C1F5A260");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.EndsAt)
                    .HasColumnName("ends_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsAvailable).HasColumnName("is_available");

                entity.Property(e => e.MetaTitle)
                    .HasColumnName("meta_title")
                    .HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductDescription)
                    .HasColumnName("product_description")
                    .HasMaxLength(500);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("product_name")
                    .HasMaxLength(100);

                entity.Property(e => e.ProductPic)
                    .HasColumnName("product_pic")
                    .HasMaxLength(500);

                entity.Property(e => e.ProductSummery)
                    .IsRequired()
                    .HasColumnName("product_summery")
                    .HasMaxLength(250);

                entity.Property(e => e.ProductType)
                    .IsRequired()
                    .HasColumnName("product_type")
                    .HasMaxLength(10);

                entity.Property(e => e.PublishedAt)
                    .HasColumnName("published_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasColumnName("sku")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.StartsAt)
                    .HasColumnName("starts_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.VendorId).HasColumnName("vendor_id");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("FK__Products__vendor__6E01572D");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.TagId).HasColumnName("tag_id");

                entity.Property(e => e.MetaTitle)
                    .HasColumnName("meta_title")
                    .HasMaxLength(200);

                entity.Property(e => e.TagTitle)
                    .IsRequired()
                    .HasColumnName("tag_title")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<UserLoginAttemptHistory>(entity =>
            {
                entity.ToTable("userLoginAttemptHistory");

                entity.Property(e => e.UserLoginAttemptHistoryId).HasColumnName("userLoginAttemptHistory_id");

                entity.Property(e => e.AttemptAt)
                    .HasColumnName("attempt_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LoginSuccess).HasColumnName("login_success");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLoginAttemptHistory)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__userLogin__userI__6477ECF3");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__CB9A1CFFBCFAD780");

                entity.HasIndex(e => e.UserEmail)
                    .HasName("UQ__Users__B0FBA212E63910CC")
                    .IsUnique();

                entity.HasIndex(e => e.UserMobile)
                    .HasName("UQ__Users__0C17057EC3762B58")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsAdmin).HasColumnName("is_admin");

                entity.Property(e => e.IsVendor).HasColumnName("is_vendor");

                entity.Property(e => e.LockedOut).HasColumnName("locked_out");

                entity.Property(e => e.PasswordHash)
                    .HasColumnName("password_hash")
                    .HasMaxLength(500);

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasColumnName("user_email")
                    .HasMaxLength(100);

                entity.Property(e => e.UserFname)
                    .IsRequired()
                    .HasColumnName("user_fname")
                    .HasMaxLength(50);

                entity.Property(e => e.UserIntro)
                    .HasColumnName("user_intro")
                    .HasMaxLength(250);

                entity.Property(e => e.UserLname)
                    .IsRequired()
                    .HasColumnName("user_lname")
                    .HasMaxLength(50);

                entity.Property(e => e.UserMname)
                    .IsRequired()
                    .HasColumnName("user_mname")
                    .HasMaxLength(50);

                entity.Property(e => e.UserMobile)
                    .IsRequired()
                    .HasColumnName("user_mobile")
                    .HasMaxLength(15);

                entity.Property(e => e.UserProfile)
                    .HasColumnName("user_profile")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<UsersAddress>(entity =>
            {
                entity.HasKey(e => e.UserAddressId)
                    .HasName("PK__Users_ad__FEC0352EF043B568");

                entity.ToTable("Users_address");

                entity.Property(e => e.UserAddressId).HasColumnName("user_address_id");

                entity.Property(e => e.UserAddress1)
                    .HasColumnName("user_address1")
                    .HasMaxLength(100);

                entity.Property(e => e.UserAddress2)
                    .HasColumnName("user_address2")
                    .HasMaxLength(100);

                entity.Property(e => e.UserAddress3)
                    .HasColumnName("user_address3")
                    .HasMaxLength(100);

                entity.Property(e => e.UserCity)
                    .HasColumnName("user_city")
                    .HasMaxLength(50);

                entity.Property(e => e.UserCo)
                    .HasColumnName("user_co")
                    .HasMaxLength(50);

                entity.Property(e => e.UserCountry)
                    .IsRequired()
                    .HasColumnName("user_country")
                    .HasMaxLength(50);

                entity.Property(e => e.UserEmail1)
                    .HasColumnName("user_email1")
                    .HasMaxLength(50);

                entity.Property(e => e.UserEmail2)
                    .HasColumnName("user_email2")
                    .HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.UserPhone1)
                    .HasColumnName("user_phone1")
                    .HasMaxLength(10);

                entity.Property(e => e.UserPhone2)
                    .HasColumnName("user_phone2")
                    .HasMaxLength(10);

                entity.Property(e => e.UserPostalCode).HasColumnName("user_postal_code");

                entity.Property(e => e.UserState)
                    .HasColumnName("user_state")
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersAddress)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users_add__userI__68487DD7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
