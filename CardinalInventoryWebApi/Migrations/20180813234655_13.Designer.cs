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
    [Migration("20180813234655_13")]
    partial class _13
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CardinalInventoryWebApi.Data.EventManagement.Event", b =>
                {
                    b.Property<Guid>("EventId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Completed");

                    b.Property<string>("Description");

                    b.HasKey("EventId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.EventManagement.EventCustomer", b =>
                {
                    b.Property<Guid>("EventCustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ApplicationUserId");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("TimeStamp");

                    b.HasKey("EventCustomerId");

                    b.ToTable("EventCustomers");
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.EventManagement.EventStation", b =>
                {
                    b.Property<Guid>("EventStationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("Hardware");

                    b.HasKey("EventStationId");

                    b.ToTable("EventStations");
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.EventManagement.EventStationAssignment", b =>
                {
                    b.Property<Guid>("EventId");

                    b.Property<Guid>("EventStationId");

                    b.Property<int>("ControlType");

                    b.Property<Guid>("EventTicketAdmissionTypeId");

                    b.Property<Guid>("GateEventTicketAdmissionTypeId");

                    b.HasKey("EventId", "EventStationId");

                    b.HasIndex("EventStationId");

                    b.HasIndex("EventTicketAdmissionTypeId");

                    b.HasIndex("GateEventTicketAdmissionTypeId");

                    b.ToTable("EventStationAssignments");
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.EventManagement.EventTicket", b =>
                {
                    b.Property<Guid>("EventTicketId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Enabled");

                    b.Property<Guid>("EventCustomerId");

                    b.Property<Guid>("EventId");

                    b.Property<Guid>("EventTicketAdmissionTypeId");

                    b.Property<int>("TicketPhysicalType");

                    b.Property<string>("UniqueIdentifier")
                        .IsRequired();

                    b.HasKey("EventTicketId");

                    b.HasIndex("EventCustomerId");

                    b.HasIndex("EventId");

                    b.HasIndex("EventTicketAdmissionTypeId");

                    b.ToTable("EventTickets");
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.EventManagement.EventTicketAdmissionType", b =>
                {
                    b.Property<Guid>("EventTicketAdmissionTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<Guid>("EventId");

                    b.Property<int>("Level");

                    b.HasKey("EventTicketAdmissionTypeId");

                    b.HasIndex("EventId");

                    b.ToTable("EventTicketAdmissionTypes");
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.EventManagement.EventTicketHistory", b =>
                {
                    b.Property<Guid>("EventTicketHistoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ApplicationUserId");

                    b.Property<string>("ColumnChanged");

                    b.Property<Guid>("EventTicketId");

                    b.Property<string>("NewValue");

                    b.Property<string>("OldValue");

                    b.Property<DateTime>("TimeStamp");

                    b.HasKey("EventTicketHistoryId");

                    b.ToTable("EventTicketHistories");
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.EventManagement.EventTicketStatus", b =>
                {
                    b.Property<Guid>("EventTicketId");

                    b.Property<Guid>("EventTicketAdmissionTypeId");

                    b.Property<DateTime>("TimeStamp");

                    b.HasKey("EventTicketId", "EventTicketAdmissionTypeId");

                    b.HasIndex("EventTicketAdmissionTypeId");

                    b.ToTable("EventTicketStatuses");
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.EventManagement.EventTicketStatusHistory", b =>
                {
                    b.Property<Guid>("EventTicketStatusHistoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EventStationControlType");

                    b.Property<Guid>("EventStationId");

                    b.Property<int>("EventStationProcessResult");

                    b.Property<Guid>("EventTicketAdmissionTypeId");

                    b.Property<Guid>("EventTicketId");

                    b.Property<DateTime>("TimeStamp");

                    b.HasKey("EventTicketStatusHistoryId");

                    b.HasIndex("EventStationId");

                    b.HasIndex("EventTicketAdmissionTypeId");

                    b.HasIndex("EventTicketId");

                    b.ToTable("EventTicketStatusHistories");
                });

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
                        .HasColumnType("decimal(8,2)");

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
                        .HasColumnType("decimal(8,2)");

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

                    b.Property<decimal>("CurrentItemLevel")
                        .HasColumnType("decimal(4,3)");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<DateTime>("ReceivedDate");

                    b.Property<Guid>("StockItemId");

                    b.Property<decimal>("UnitCost")
                        .HasColumnType("decimal(8,2)");

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
                        .HasColumnType("decimal(8,2)");

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

            modelBuilder.Entity("CardinalInventoryWebApi.Data.SmartWatch.PourSpout", b =>
                {
                    b.Property<Guid>("PourSpoutId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<double>("DurationForOneLiter");

                    b.Property<string>("ImagePath");

                    b.HasKey("PourSpoutId");

                    b.ToTable("PourSpouts");
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.SmartWatch.SmartWatchSession", b =>
                {
                    b.Property<Guid>("SmartWatchSessionId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("AttitudeRollOffset");

                    b.Property<string>("Description");

                    b.Property<decimal>("IntervalDuration")
                        .HasColumnType("decimal(5,3)");

                    b.Property<int>("IntervalStart");

                    b.Property<int>("IntervalStop");

                    b.Property<Guid>("PourSpoutId");

                    b.Property<DateTime>("Timestamp");

                    b.Property<int>("WristOrientation");

                    b.HasKey("SmartWatchSessionId");

                    b.HasIndex("PourSpoutId");

                    b.ToTable("SmartWatchSessions");
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.SmartWatch.SmartWatchSessionData", b =>
                {
                    b.Property<int>("Interval");

                    b.Property<Guid>("SmartWatchSessionId");

                    b.Property<double>("AccelerometerX");

                    b.Property<double>("AccelerometerY");

                    b.Property<double>("AccelerometerZ");

                    b.Property<double>("AttitudePitch");

                    b.Property<double>("AttitudeRoll");

                    b.Property<double>("AttitudeYaw");

                    b.Property<double>("RotationRateX");

                    b.Property<double>("RotationRateY");

                    b.Property<double>("RotationRateZ");

                    b.Property<double>("UserAccelerationX");

                    b.Property<double>("UserAccelerationY");

                    b.Property<double>("UserAccelerationZ");

                    b.HasKey("Interval", "SmartWatchSessionId");

                    b.HasIndex("SmartWatchSessionId");

                    b.ToTable("SmartWatchSessionData");
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

            modelBuilder.Entity("CardinalInventoryWebApi.Data.EventManagement.EventStationAssignment", b =>
                {
                    b.HasOne("CardinalInventoryWebApi.Data.EventManagement.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CardinalInventoryWebApi.Data.EventManagement.EventStation", "EventStation")
                        .WithMany()
                        .HasForeignKey("EventStationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CardinalInventoryWebApi.Data.EventManagement.EventTicketAdmissionType", "EventTicketAdmissionType")
                        .WithMany()
                        .HasForeignKey("EventTicketAdmissionTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CardinalInventoryWebApi.Data.EventManagement.EventTicketAdmissionType", "GateEventTicketAdmissionType")
                        .WithMany()
                        .HasForeignKey("GateEventTicketAdmissionTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.EventManagement.EventTicket", b =>
                {
                    b.HasOne("CardinalInventoryWebApi.Data.EventManagement.EventCustomer", "EventCustomer")
                        .WithMany()
                        .HasForeignKey("EventCustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CardinalInventoryWebApi.Data.EventManagement.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CardinalInventoryWebApi.Data.EventManagement.EventTicketAdmissionType", "EventTicketAdmissionType")
                        .WithMany()
                        .HasForeignKey("EventTicketAdmissionTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.EventManagement.EventTicketAdmissionType", b =>
                {
                    b.HasOne("CardinalInventoryWebApi.Data.EventManagement.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.EventManagement.EventTicketStatus", b =>
                {
                    b.HasOne("CardinalInventoryWebApi.Data.EventManagement.EventTicketAdmissionType", "EventTicketAdmissionType")
                        .WithMany()
                        .HasForeignKey("EventTicketAdmissionTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CardinalInventoryWebApi.Data.EventManagement.EventTicket", "EventTicket")
                        .WithMany()
                        .HasForeignKey("EventTicketId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.EventManagement.EventTicketStatusHistory", b =>
                {
                    b.HasOne("CardinalInventoryWebApi.Data.EventManagement.EventStation", "EventStation")
                        .WithMany()
                        .HasForeignKey("EventStationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CardinalInventoryWebApi.Data.EventManagement.EventTicketAdmissionType", "EventTicketAdmissionType")
                        .WithMany()
                        .HasForeignKey("EventTicketAdmissionTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CardinalInventoryWebApi.Data.EventManagement.EventTicket", "EventTicket")
                        .WithMany()
                        .HasForeignKey("EventTicketId")
                        .OnDelete(DeleteBehavior.Restrict);
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

            modelBuilder.Entity("CardinalInventoryWebApi.Data.SmartWatch.SmartWatchSession", b =>
                {
                    b.HasOne("CardinalInventoryWebApi.Data.SmartWatch.PourSpout", "PourSpout")
                        .WithMany()
                        .HasForeignKey("PourSpoutId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CardinalInventoryWebApi.Data.SmartWatch.SmartWatchSessionData", b =>
                {
                    b.HasOne("CardinalInventoryWebApi.Data.SmartWatch.SmartWatchSession", "SmartWatchSession")
                        .WithMany()
                        .HasForeignKey("SmartWatchSessionId")
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
