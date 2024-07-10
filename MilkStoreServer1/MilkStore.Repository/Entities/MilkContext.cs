using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MilkStore.Repo.Entities
{
    public partial class MilkContext : DbContext
    {
        public MilkContext()
        {
        }

        public MilkContext(DbContextOptions<MilkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<AgeRange> AgeRanges { get; set; }
        public virtual DbSet<BrandMilk> BrandMilks { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DeliveryMan> DeliveryMen { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<ProductItem> ProductItems { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=alien123.database.windows.net,1433;Database=Milk;User Id=sa;Password=12345;TrustServerCertificate=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.AdminID).HasName("PK__Admin__719FE4E89570F68B");

                entity.ToTable("Admin");

                entity.Property(e => e.AdminID)
                    .ValueGeneratedOnAdd() // Tự động tăng giá trị (IDENTITY)
                    .HasColumnName("AdminID");

                entity.Property(e => e.Username)
                    .HasColumnType("nvarchar(max)")
                    .IsRequired();

                entity.Property(e => e.Password)
                    .HasColumnType("nvarchar(max)")
                    .IsRequired();

                entity.Property(e => e.Role)
                    .HasColumnType("nvarchar(max)")
                    .IsRequired();

                entity.Property(e => e.Delete)
                    .HasColumnType("nvarchar(max)")
                    .HasDefaultValue("No") // Giá trị mặc định là 'No'
                    .IsRequired();
            });


            modelBuilder.Entity<AgeRange>(entity =>
            {
                entity.HasKey(e => e.AgeRangeID).HasName("PK__AgeRange__8CC41DB1F51D4D6D");

                entity.ToTable("AgeRange");

                entity.Property(e => e.AgeRangeID)
                    .ValueGeneratedOnAdd() // Tự động tăng giá trị (IDENTITY)
                    .HasColumnName("AgeRangeID");

                entity.Property(e => e.Baby)
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.Mama)
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.ProductItemID)
                    .HasColumnName("ProductItemID");

                entity.Property(e => e.Delete)
                    .HasColumnType("nvarchar(max)")
                    .HasDefaultValue("No") // Giá trị mặc định là 'No'
                    .IsRequired();

                entity.HasOne(d => d.ProductItem).WithMany(p => p.AgeRanges)
                    .HasForeignKey(d => d.ProductItemID)
                    .HasConstraintName("FK__AgeRange__Produc__4AB81AF0");
            });


            modelBuilder.Entity<BrandMilk>(entity =>
            {
                entity.ToTable("BrandMilk");

                entity.HasKey(e => e.BrandMilkID).HasName("PK__BrandMil__03987540F41D4097");

                entity.Property(e => e.BrandMilkID)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BrandMilkID");

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.CompanyID)
                    .HasColumnName("CompanyID");

                entity.Property(e => e.Delete)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)")
                    .HasDefaultValue("No");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.BrandMilks)
                    .HasForeignKey(d => d.CompanyID)
                    .HasConstraintName("FK__BrandMilk__Compa__3C69FB99");
            });


            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.HasKey(e => e.CompanyID).HasName("PK__Company__2D971C4CC3C9BC4A");

                entity.Property(e => e.CompanyID)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CompanyID");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.CountryID)
                    .HasColumnName("CountryID");

                entity.Property(e => e.Delete)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)")
                    .HasDefaultValue("No");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.CountryID)
                    .HasConstraintName("FK__Company__Country__398D8EEE");
            });


            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.HasKey(e => e.CountryId).HasName("PK__Country__10D160BF16269C1F");

                entity.Property(e => e.CountryId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CountryID");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.Delete)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)")
                    .HasDefaultValue("No");
            });


            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.HasKey(e => e.CustomerID).HasName("PK__Customer__A4AE64B8F3DA30BC");

                entity.Property(e => e.CustomerID)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CustomerID");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Delete)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)")
                    .HasDefaultValue("No");

                entity.HasMany(e => e.Orders)
                    .WithOne(o => o.Customer)
                    .HasForeignKey(o => o.CustomerId)
                    .HasConstraintName("FK__Order__CustomerID");

                entity.HasMany(e => e.OrderDetails)
                    .WithOne(od => od.Customer)
                    .HasForeignKey(od => od.CustomerId)
                    .HasConstraintName("FK__OrderDetail__CustomerID");
            });


            modelBuilder.Entity<DeliveryMan>(entity =>
            {
                entity.ToTable("DeliveryMan");

                entity.HasKey(e => e.DeliveryManId).HasName("PK__Delivery__E33EAD9D404385B3");

                entity.Property(e => e.DeliveryManId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DeliveryManID");

                entity.Property(e => e.DeliveryName)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.DeliveryStatus)
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.StorageId)
                    .HasColumnName("StorageID");

                entity.Property(e => e.StorageName)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.Delete)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)")
                    .HasDefaultValue("No");

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.DeliveryMen)
                    .HasForeignKey(d => d.StorageId)
                    .HasConstraintName("FK__DeliveryM__Stora__44FF419A");
            });


            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BAFDB0EA8FB");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("OrderID");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID");

                entity.Property(e => e.DeliveryManId)
                    .HasColumnName("DeliveryManID");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("OrderDate");

                entity.Property(e => e.ShippingAddress)
                    .IsRequired()
                    .HasColumnName("ShippingAddress")
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("TotalAmount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.StorageId)
                    .HasColumnName("StorageID");

                entity.Property(e => e.DeliveryName)
                    .HasColumnName("DeliveryName")
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.DeliveryPhone)
                    .HasColumnName("DeliveryPhone")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasColumnName("PaymentMethod")
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("Status")
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.Delete)
                    .IsRequired()
                    .HasColumnName("Delete")
                    .HasColumnType("nvarchar(max)")
                    .HasDefaultValue("No");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Order__CustomerID__4D94879B");

                entity.HasOne(d => d.DeliveryMan)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DeliveryManId)
                    .HasConstraintName("FK__Order__DeliveryManID__4E88ABD4");

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StorageId)
                    .HasConstraintName("FK__Order__StorageID__4F7CD00D");
            });


            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.HasKey(e => e.OrderDetailId).HasName("PK_OrderDetail");

                entity.Property(e => e.OrderDetailId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("OrderDetailID");

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID");

                entity.Property(e => e.ProductItemId)
                    .HasColumnName("ProductItemID");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnName("ItemName")
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.Image)
                    .HasColumnName("Image")
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("Quantity");

                entity.Property(e => e.Price)
                    .HasColumnName("Price")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Discount)
                    .HasColumnName("Discount")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.StockQuantity)
                    .HasColumnName("StockQuantity");

                entity.Property(e => e.Delete)
                    .IsRequired()
                    .HasColumnName("Delete")
                    .HasColumnType("nvarchar(max)")
                    .HasDefaultValue("No");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetail_Order");

                entity.HasOne(d => d.ProductItem)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductItemId)
                    .HasConstraintName("FK_OrderDetail_ProductItem");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_OrderDetail_CustomerID");
            });




            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.HasKey(e => e.PaymentId).HasName("PK__Payment__9B556A588635E4E4");

                entity.Property(e => e.PaymentId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PaymentID");

                entity.Property(e => e.Amount)
                    .IsRequired()
                    .HasColumnName("Amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasColumnName("PaymentMethod")
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID");

                entity.Property(e => e.Delete)
                    .IsRequired()
                    .HasColumnName("Delete")
                    .HasColumnType("nvarchar(max)")
                    .HasDefaultValue("No");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Payment__OrderID__52593CB8");
            });


            modelBuilder.Entity<ProductItem>(entity =>
            {
                entity.ToTable("ProductItem");

                entity.HasKey(e => e.ProductItemId).HasName("PK_ProductItem_ProductItemId");

                entity.Property(e => e.ProductItemId)
                    .HasColumnName("ProductItemID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Benefit)
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.Description)
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.Image1)
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.Image2)
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.Image3)
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Discount)
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Weight)
                    .HasColumnType("float");

                entity.Property(e => e.BrandMilkId)
                    .HasColumnName("BrandMilkID");

                entity.Property(e => e.Baby)
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.Mama)
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.SoldQuantity)
                    .HasColumnType("int");

                entity.Property(e => e.StockQuantity)
                    .HasColumnType("int");

                entity.Property(e => e.Delete)
                    .IsRequired()
                    .HasColumnName("Delete")
                    .HasColumnType("nvarchar(max)")
                    .HasDefaultValue("No");

                entity.HasOne(d => d.BrandMilk)
                    .WithMany(p => p.ProductItems)
                    .HasForeignKey(d => d.BrandMilkId)
                    .HasConstraintName("FK_ProductItem_BrandMilk_BrandMilkID");
            });



            modelBuilder.Entity<Storage>(entity =>
            {
                entity.ToTable("Storage");

                entity.HasKey(e => e.StorageId).HasName("PK__Storage__8A247E37BE5A39BF");

                entity.Property(e => e.StorageId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("StorageID");

                entity.Property(e => e.StorageName)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.Delete)
                    .IsRequired()
                    .HasColumnName("Delete")
                    .HasColumnType("nvarchar(max)")
                    .HasDefaultValue("No");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
