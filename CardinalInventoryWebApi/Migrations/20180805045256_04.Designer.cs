﻿// <auto-generated />
using System;
using CardinalInventoryWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CardinalInventoryWebApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180805045256_04")]
    partial class _04
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CardinalInventoryWebApi.Data.Models.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<bool>("Active");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.Models.Area", b =>
                {
                    b.Property<Guid>("AreaId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Description");

                    b.Property<Guid>("FloorId");

                    b.HasKey("AreaId");

                    b.HasIndex("FloorId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.Models.Bar", b =>
                {
                    b.Property<Guid>("BarId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<Guid>("CompanyId");

                    b.Property<string>("Description");

                    b.HasKey("BarId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Bars");
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.Models.Building", b =>
                {
                    b.Property<Guid>("BuildingId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<Guid>("BarId");

                    b.Property<string>("Description");

                    b.HasKey("BuildingId");

                    b.HasIndex("BarId");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.Models.Company", b =>
                {
                    b.Property<Guid>("CompanyId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Description");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.Models.Floor", b =>
                {
                    b.Property<Guid>("FloorId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<Guid>("BuildingId");

                    b.Property<string>("Description");

                    b.HasKey("FloorId");

                    b.HasIndex("BuildingId");

                    b.ToTable("Floors");
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.Models.InventoryActionHistory", b =>
                {
                    b.Property<Guid>("InventoryActionHistoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Action");

                    b.Property<Guid>("ApplicationUserId");

                    b.Property<Guid>("AreaId");

                    b.Property<decimal>("ItemLevel")
                        .HasColumnType("decimal(6,2)");

                    b.Property<Guid>("SerializedStockItemId");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("InventoryActionHistoryId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("AreaId");

                    b.HasIndex("SerializedStockItemId");

                    b.ToTable("InventoryActionHistories");
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.Models.InventoryHistory", b =>
                {
                    b.Property<Guid>("InventoryHistoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AreaId");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(6,2)");

                    b.Property<Guid>("StockItemId");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("InventoryHistoryId");

                    b.HasIndex("AreaId");

                    b.HasIndex("StockItemId");

                    b.ToTable("InventoryHistories");
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.Models.SerializedStockItem", b =>
                {
                    b.Property<Guid>("SerializedStockItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AreaId");

                    b.Property<string>("Barcode")
                        .IsRequired();

                    b.Property<decimal>("CurrentItemLevel");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<DateTime>("ReceivedDate");

                    b.Property<Guid>("StockItemId");

                    b.Property<decimal>("UnitCost")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("SerializedStockItemId");

                    b.HasIndex("AreaId");

                    b.HasIndex("StockItemId");

                    b.ToTable("SerializedStockItems");
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.Models.StockItem", b =>
                {
                    b.Property<Guid>("StockItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("ImagePath");

                    b.Property<string>("SKU");

                    b.Property<decimal>("UnitCost")
                        .HasColumnType("decimal(6,2)");

                    b.Property<int>("UnitSizeMilliliters");

                    b.HasKey("StockItemId");

                    b.ToTable("StockItems");
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.Models.StockItemTag", b =>
                {
                    b.Property<Guid>("StockItemTagId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("StockItemId");

                    b.Property<string>("Tag");

                    b.HasKey("StockItemTagId");

                    b.HasIndex("StockItemId");

                    b.ToTable("StockItemTags");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.Models.Area", b =>
                {
                    b.HasOne("CardinalInventoryWebApi.Data.Models.Floor", "Floor")
                        .WithMany()
                        .HasForeignKey("FloorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.Models.Bar", b =>
                {
                    b.HasOne("CardinalInventoryWebApi.Data.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.Models.Building", b =>
                {
                    b.HasOne("CardinalInventoryWebApi.Data.Models.Bar", "Bar")
                        .WithMany()
                        .HasForeignKey("BarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.Models.Floor", b =>
                {
                    b.HasOne("CardinalInventoryWebApi.Data.Models.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.Models.InventoryActionHistory", b =>
                {
                    b.HasOne("CardinalInventoryWebApi.Data.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CardinalInventoryWebApi.Data.Models.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CardinalInventoryWebApi.Data.Models.SerializedStockItem", "SerializedStockItem")
                        .WithMany()
                        .HasForeignKey("SerializedStockItemId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.Models.InventoryHistory", b =>
                {
                    b.HasOne("CardinalInventoryWebApi.Data.Models.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CardinalInventoryWebApi.Data.Models.StockItem", "StockItem")
                        .WithMany()
                        .HasForeignKey("StockItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.Models.SerializedStockItem", b =>
                {
                    b.HasOne("CardinalInventoryWebApi.Data.Models.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CardinalInventoryWebApi.Data.Models.StockItem", "StockItem")
                        .WithMany()
                        .HasForeignKey("StockItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.Models.StockItemTag", b =>
                {
                    b.HasOne("CardinalInventoryWebApi.Data.Models.StockItem", "StockItem")
                        .WithMany()
                        .HasForeignKey("StockItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("CardinalInventoryWebApi.Data.Models.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("CardinalInventoryWebApi.Data.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("CardinalInventoryWebApi.Data.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("CardinalInventoryWebApi.Data.Models.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CardinalInventoryWebApi.Data.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("CardinalInventoryWebApi.Data.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
