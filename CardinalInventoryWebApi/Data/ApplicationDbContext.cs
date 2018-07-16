using System;
using System.Collections.Generic;
using System.Text;
using CardinalInventoryWebApi.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CardinalInventoryWebApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<StockItemCategory>()
                   .HasKey(s => s.StockItemCategoryId);

            builder.Entity<StockItem>()
                   .HasKey(s => s.StockItemId);
            builder.Entity<StockItem>()
                   .HasOne(i => i.StockItemCategory)
                   .WithMany()
                   .HasForeignKey("StockItemCategoryId");
            builder.Entity<StockItem>()
                   .Property(i => i.UnitCost)
                   .HasColumnType("decimal(6,2)");

            builder.Entity<Bar>()
                   .HasKey(b => b.BarId);

            builder.Entity<Building>()
                   .HasKey(b => b.BuildingId);
            builder.Entity<Building>()
                   .HasOne(i => i.Bar)
                   .WithMany()
                   .HasForeignKey("BarId");

            builder.Entity<Area>()
                   .HasKey(a => a.AreaId);
            builder.Entity<Area>()
                   .HasOne(i => i.Building)
                   .WithMany()
                   .HasForeignKey("BuildingId");

            builder.Entity<InventoryActionHistory>()
                   .HasKey(a => a.InventoryActionHistoryId);
            builder.Entity<InventoryActionHistory>()
                   .HasOne(i => i.Area)
                   .WithMany()
                   .HasForeignKey("AreaId");
            builder.Entity<InventoryActionHistory>()
                   .HasOne(i => i.StockItem)
                   .WithMany()
                   .HasForeignKey("StockItemId");
            builder.Entity<InventoryActionHistory>()
                   .HasOne(i => i.ApplicationUser)
                   .WithMany()
                   .HasForeignKey("ApplicationUserId");
            builder.Entity<InventoryActionHistory>()
                   .Property(i => i.ItemLevel)
                   .HasColumnType("decimal(6,2)");

            builder.Entity<InventoryHistory>()
                   .HasKey(a => a.InventoryHistoryId);
            builder.Entity<InventoryHistory>()
                   .HasOne(i => i.Area)
                   .WithMany()
                   .HasForeignKey("AreaId");
            builder.Entity<InventoryHistory>()
                   .HasOne(i => i.StockItem)
                   .WithMany()
                   .HasForeignKey("StockItemId");
            builder.Entity<InventoryHistory>()
                   .Property(i => i.Quantity)
                   .HasColumnType("decimal(6,2)");
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<StockItemCategory> StockItemCategories { get; set; }
        public DbSet<StockItem> StockItems { get; set; }
        public DbSet<Bar> Bars { get; set; }
        public DbSet<Building> Buidings { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<InventoryActionHistory> InventoryActionHistories { get; set; }
        public DbSet<InventoryHistory> InventoryHistories { get; set; }
    }
}
