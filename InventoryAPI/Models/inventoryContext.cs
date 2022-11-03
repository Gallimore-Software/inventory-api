using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace InventoryAPI.Models
{
    public partial class inventoryContext : DbContext
    {
        public inventoryContext()
        {
        }

        public inventoryContext(DbContextOptions<inventoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=InventoryDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("images");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.ImageName)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("image_name");

                entity.Property(e => e.ItemId).HasColumnName("item_id");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("items");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("category");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("total");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK__items__supplier___0E6E26BF");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Contact)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("contact");

                entity.Property(e => e.Description)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Tax)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("tax");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("total");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK__orders__item_id__14270015");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("suppliers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Contact)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("contact");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Contact)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("contact");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
