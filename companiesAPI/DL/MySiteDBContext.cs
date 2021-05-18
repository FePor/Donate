using System;
using Microsoft.EntityFrameworkCore;
using Entities;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DL
{

    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options)
            : base(options)
        {
        }

        public DbSet<CompanyItem> CompanyItems { get; set; }
    }
//    public partial class MySiteDBContext : DbContext
//    {
//       // public CompanyContext(DbContextOptions<CompanyContext> options)
//       //: base(options)
//       // {
//       // }

//       // public DbSet<CompanyItem> CompanyItems { get; set; }
//        public MySiteDBContext()
//        {
//        }

//        public MySiteDBContext(DbContextOptions<MySiteDBContext> options)
//            : base(options)
//        {
//            this.ChangeTracker.LazyLoadingEnabled = false;
//        }

//        public virtual DbSet<OrderItem> OrderItem { get; set; }
//        public virtual DbSet<Orders> Orders { get; set; }

////        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
////        {
////            if (!optionsBuilder.IsConfigured)
////            {
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
////                optionsBuilder.UseSqlServer("Server=Desktop-V6KSTL4;Database=MySiteDB;Trusted_Connection=True;");
////            }
////        }

////        protected override void OnModelCreating(ModelBuilder modelBuilder)
////        {
////            modelBuilder.Entity<Categories>(entity =>
////            {
////                entity.HasKey(e => e.CategoryId);

////                entity.ToTable("CATEGORIES");

////                entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");

////                entity.Property(e => e.CategoryName)
////                    .HasColumnName("CATEGORY_NAME")
////                    .HasMaxLength(20);
////            });

////            modelBuilder.Entity<OrderItem>(entity =>
////            {
////                entity.ToTable("ORDER_ITEM");

////                entity.Property(e => e.OrderItemId).HasColumnName("ORDER_ITEM_ID");

////                entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");

////                entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");

////                entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

////                entity.HasOne(d => d.Order)
////                    .WithMany(p => p.OrderItem)
////                    .HasForeignKey(d => d.OrderId)
////                    .HasConstraintName("FK_OI_ORDER");

////                entity.HasOne(d => d.Product)
////                    .WithMany(p => p.OrderItem)
////                    .HasForeignKey(d => d.ProductId)
////                    .HasConstraintName("FK_OI_PRODUCT");
////            });

////            modelBuilder.Entity<Orders>(entity =>
////            {
////                entity.HasKey(e => e.OrderId);

////                entity.ToTable("ORDERS");

////                entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");

////                entity.Property(e => e.OrderDate)
////                    .HasColumnName("ORDER_DATE")
////                    .HasColumnType("datetime");

////                entity.Property(e => e.OrderSum).HasColumnName("ORDER_SUM");

////                entity.Property(e => e.UserId).HasColumnName("USER_ID");

////                entity.HasOne(d => d.User)
////                    .WithMany(p => p.Orders)
////                    .HasForeignKey(d => d.UserId)
////                    .HasConstraintName("FK_ORDERS_USERS");
////            });

////            modelBuilder.Entity<Products>(entity =>
////            {
////                entity.HasKey(e => e.ProductId);

////                entity.ToTable("PRODUCTS");

////                entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");

////                entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");

////                entity.Property(e => e.Description)
////                    .HasColumnName("DESCRIPTION")
////                    .HasMaxLength(100)
////                    .IsFixedLength();

////                entity.Property(e => e.ImageUrl)
////                  .HasColumnName("IMAGE_URL")
////                  .HasMaxLength(100)
////                  .IsFixedLength();

////                entity.Property(e => e.Price).HasColumnName("PRICE");

////                entity.Property(e => e.ProductName)
////                    .HasColumnName("PRODUCT_NAME")
////                    .HasMaxLength(50);

////                entity.HasOne(d => d.Category)
////                    .WithMany(p => p.Products)
////                    .HasForeignKey(d => d.CategoryId)
////                    .HasConstraintName("FK_PRODUCTS_CATEGORY");
////            });

////            modelBuilder.Entity<Rating>(entity =>
////            {
////                entity.ToTable("RATING");

////                entity.Property(e => e.RatingId).HasColumnName("RATING_ID");

////                entity.Property(e => e.Host)
////                    .HasColumnName("HOST")
////                    .HasMaxLength(50);

////                entity.Property(e => e.Method)
////                    .HasColumnName("METHOD")
////                    .HasMaxLength(10)
////                    .IsFixedLength();

////                entity.Property(e => e.Path)
////                    .HasColumnName("PATH")
////                    .HasMaxLength(50);

////                entity.Property(e => e.RecordDate)
////                 .HasColumnName("Record_Date")
////                 .HasColumnType("datetime");

////                entity.Property(e => e.Referer)
////                    .HasColumnName("REFERER")
////                    .HasMaxLength(100);

////                entity.Property(e => e.UserAgent).HasColumnName("USER_AGENT");
////            });

////            modelBuilder.Entity<Users>(entity =>
////            {
////                entity.HasKey(e => e.UserId);

////                entity.ToTable("USERS");

////                entity.Property(e => e.UserId).HasColumnName("USER_ID");

////                entity.Property(e => e.Email)
////                    .HasColumnName("EMAIL")
////                    .HasMaxLength(50);

////                entity.Property(e => e.FirstName)
////                    .HasColumnName("FIRST_NAME")
////                    .HasMaxLength(10)
////                    .IsFixedLength();

////                entity.Property(e => e.LastName)
////                    .HasColumnName("LAST_NAME")
////                    .HasMaxLength(20);

////                entity.Property(e => e.Password)
////                    .HasColumnName("PASSWORD")
////                    .HasMaxLength(10)
////                    .IsFixedLength();
////            });

////            OnModelCreatingPartial(modelBuilder);
////        }

////        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
}
