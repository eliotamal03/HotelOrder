using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HotelOrder.Models
{
    public partial class HotelOrderModelDbContext : DbContext
    {
        public HotelOrderModelDbContext()
        {
        }

        public HotelOrderModelDbContext(DbContextOptions<HotelOrderDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OrderTracking> OrderTracking { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<StaticDiningTables> StaticDiningTables { get; set; }
        public virtual DbSet<StaticMenuHeaders> StaticMenuHeaders { get; set; }
        public virtual DbSet<StaticMenus> StaticMenus { get; set; }
        public virtual DbSet<StaticOrdersStatus> StaticOrdersStatus { get; set; }
        public virtual DbSet<StaticPreferences> StaticPreferences { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-LN951Q9;Database=HotelOrderDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderTracking>(entity =>
            {
                entity.ToTable("order_tracking");

                entity.Property(e => e.OrderTrackingId).HasColumnName("order_tracking_id");

                entity.Property(e => e.CreatedTimeStamp)
                    .HasColumnName("created_time_stamp")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderNumber)
                    .HasColumnName("order_number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderStatusId).HasColumnName("order_status_id");

                entity.Property(e => e.UpdatedTimeStamp)
                    .HasColumnName("updated_time_stamp")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.OrderNumberNavigation)
                    .WithMany(p => p.OrderTracking)
                    .HasPrincipalKey(p => p.OrderNumber)
                    .HasForeignKey(d => d.OrderNumber)
                    .HasConstraintName("FK_order_tracking_orders");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.OrderTracking)
                    .HasForeignKey(d => d.OrderStatusId)
                    .HasConstraintName("FK_order_tracking_static_orders_status");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("orders");

                entity.HasIndex(e => e.OrderNumber)
                    .HasName("IX_orders")
                    .IsUnique();

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.CreatedTimeStamp)
                    .HasColumnName("created_time_stamp")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DiningTableId).HasColumnName("dining_table_id");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MenuId).HasColumnName("menu_id");

                entity.Property(e => e.OrderNumber)
                    .IsRequired()
                    .HasColumnName("order_number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UpdatedTimeStamp)
                    .HasColumnName("updated_time_stamp")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.DiningTable)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DiningTableId)
                    .HasConstraintName("FK_orders_static_dining_tables");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("FK_orders_static_menus");
            });

            modelBuilder.Entity<StaticDiningTables>(entity =>
            {
                entity.HasKey(e => e.DiningTableId);

                entity.ToTable("static_dining_tables");

                entity.Property(e => e.DiningTableId).HasColumnName("dining_table_id");

                entity.Property(e => e.CreatedTimeStamp)
                    .HasColumnName("created_time_stamp")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DiningTableName)
                    .HasColumnName("dining_table_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedTimeStamp)
                    .HasColumnName("updated_time_stamp")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<StaticMenuHeaders>(entity =>
            {
                entity.HasKey(e => e.MenuHeaderId);

                entity.ToTable("static_menu_headers");

                entity.Property(e => e.MenuHeaderId).HasColumnName("menu_header_id");

                entity.Property(e => e.CreatedTimeStamp)
                    .HasColumnName("created_time_stamp")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MenuHeaderName)
                    .HasColumnName("menu_header_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTimeStamp)
                    .HasColumnName("updated_time_stamp")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<StaticMenus>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.ToTable("static_menus");

                entity.Property(e => e.MenuId).HasColumnName("menu_id");

                entity.Property(e => e.CreatedTimeStamp)
                    .HasColumnName("created_time_stamp")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MenuHeaderId).HasColumnName("menu_header_id");

                entity.Property(e => e.MenuName)
                    .HasColumnName("menu_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PreferenceId).HasColumnName("preference_id");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.UpdatedTimeStamp)
                    .HasColumnName("updated_time_stamp")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.MenuHeader)
                    .WithMany(p => p.StaticMenus)
                    .HasForeignKey(d => d.MenuHeaderId)
                    .HasConstraintName("FK_static_menus_static_menu_headers");

                entity.HasOne(d => d.Preference)
                    .WithMany(p => p.StaticMenus)
                    .HasForeignKey(d => d.PreferenceId)
                    .HasConstraintName("FK_static_menus_static_preferences");
            });

            modelBuilder.Entity<StaticOrdersStatus>(entity =>
            {
                entity.HasKey(e => e.OrderStatusId);

                entity.ToTable("static_orders_status");

                entity.Property(e => e.OrderStatusId).HasColumnName("order_status_id");

                entity.Property(e => e.CreatedTimeStamp)
                    .HasColumnName("created_time_stamp")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StatusName)
                    .HasColumnName("status_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTimeStamp)
                    .HasColumnName("updated_time_stamp")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<StaticPreferences>(entity =>
            {
                entity.HasKey(e => e.PreferenceId);

                entity.ToTable("static_preferences");

                entity.Property(e => e.PreferenceId).HasColumnName("preference_id");

                entity.Property(e => e.CreatedTimeStamp)
                    .HasColumnName("created_time_stamp")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PreferenceName)
                    .HasColumnName("preference_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTimeStamp)
                    .HasColumnName("updated_time_stamp")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
