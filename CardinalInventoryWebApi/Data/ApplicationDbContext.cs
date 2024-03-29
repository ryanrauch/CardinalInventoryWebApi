﻿using System;
using System.Collections.Generic;
using System.Text;
using CardinalInventoryWebApi.Data.EventManagement;
using CardinalInventoryWebApi.Data.Models;
using CardinalInventoryWebApi.Data.SmartWatch;
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

            #region Inventory DbContext
            builder.Entity<StockItem>()
                   .HasKey(s => s.StockItemId);
            builder.Entity<StockItem>()
                   .Property(i => i.UnitCost)
                   .HasColumnType("decimal(8,2)");

            builder.Entity<StockItemTag>()
                   .HasKey(s => s.StockItemTagId);
            builder.Entity<StockItemTag>()
                   .HasOne(i => i.StockItem)
                   .WithMany()
                   .HasForeignKey("StockItemId");

            builder.Entity<SerializedStockItem>()
                   .HasKey(s => s.SerializedStockItemId);
            builder.Entity<SerializedStockItem>()
                   .HasOne(i => i.StockItem)
                   .WithMany()
                   .HasForeignKey("StockItemId");
            builder.Entity<SerializedStockItem>()
                   .HasOne(i => i.Area)
                   .WithMany()
                   .HasForeignKey("AreaId");
            builder.Entity<SerializedStockItem>()
                   .Property(i => i.UnitCost)
                   .HasColumnType("decimal(8,2)");
            builder.Entity<SerializedStockItem>()
                   .Property(i => i.Barcode)
                   .IsRequired(true);
            builder.Entity<SerializedStockItem>()
                   .Property(i => i.CurrentItemLevel)
                   .HasColumnType("decimal(4,3)");

            builder.Entity<Company>()
                   .HasKey(i => i.CompanyId);

            builder.Entity<Bar>()
                   .HasKey(b => b.BarId);
            builder.Entity<Bar>()
                   .HasOne(i => i.Company)
                   .WithMany()
                   .HasForeignKey("CompanyId");

            builder.Entity<Building>()
                   .HasKey(b => b.BuildingId);
            builder.Entity<Building>()
                   .HasOne(i => i.Bar)
                   .WithMany()
                   .HasForeignKey("BarId");

            builder.Entity<Floor>()
                   .HasKey(b => b.FloorId);
            builder.Entity<Floor>()
                   .HasOne(i => i.Building)
                   .WithMany()
                   .HasForeignKey("BuildingId");

            builder.Entity<Area>()
                   .HasKey(a => a.AreaId);
            builder.Entity<Area>()
                   .HasOne(i => i.Floor)
                   .WithMany()
                   .HasForeignKey("FloorId");

            builder.Entity<InventoryActionHistory>()
                   .HasKey(a => a.InventoryActionHistoryId);
            builder.Entity<InventoryActionHistory>()
                   .HasOne(i => i.Area)
                   .WithMany()
                   .HasForeignKey("AreaId");
            builder.Entity<InventoryActionHistory>()
                   .HasOne(i => i.SerializedStockItem)
                   .WithMany()
                   .HasForeignKey("SerializedStockItemId")
                   .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<InventoryActionHistory>()
                   .HasOne(i => i.ApplicationUser)
                   .WithMany()
                   .HasForeignKey("ApplicationUserId");
            builder.Entity<InventoryActionHistory>()
                   .Property(i => i.ItemLevel)
                   .HasColumnType("decimal(8,2)");

            // possibly remove this
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
                   .HasColumnType("decimal(8,2)");

            builder.Entity<DeviceScale>()
                   .HasKey(a => a.DeviceScaleId);
            #endregion

            #region EventManagement DbContext
            builder.Entity<Event>()
                   .HasKey(e => e.EventId);
            //builder.Entity<Event>()
            //       .Property(e => e.Completed)
            //       .HasDefaultValue(false);

            builder.Entity<EventStation>()
                   .HasKey(e => e.EventStationId);

            builder.Entity<EventTicketAdmissionType>()
                   .HasKey(e => e.EventTicketAdmissionTypeId);
            builder.Entity<EventTicketAdmissionType>()
                   .HasOne(e => e.Event)
                   .WithMany()
                   .HasForeignKey("EventId");
            builder.Entity<EventTicketAdmissionType>()
                   .Property(e => e.Level)
                   .IsRequired(true);

            builder.Entity<EventStationAssignment>()
                   .HasKey(e => new { e.EventId, e.EventStationId });
            builder.Entity<EventStationAssignment>()
                   .HasOne(e => e.Event)
                   .WithMany()
                   .HasForeignKey("EventId");
            builder.Entity<EventStationAssignment>()
                   .HasOne(e => e.EventStation)
                   .WithMany()
                   .HasForeignKey("EventStationId")
                   .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<EventStationAssignment>()
                   .HasOne(e => e.EventTicketAdmissionType)
                   .WithMany()
                   .HasForeignKey("EventTicketAdmissionTypeId")
                   .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<EventStationAssignment>()
                   .HasOne(e => e.GateEventTicketAdmissionType)
                   .WithMany()
                   .HasForeignKey("GateEventTicketAdmissionTypeId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<EventCustomer>()
                   .HasKey(e => e.EventCustomerId);

            builder.Entity<EventTicket>()
                   .HasKey(e => e.EventTicketId);
            builder.Entity<EventTicket>()
                   .HasOne(e => e.Event)
                   .WithMany()
                   .HasForeignKey("EventId");
            builder.Entity<EventTicket>()
                   .HasOne(e => e.EventTicketAdmissionType)
                   .WithMany()
                   .HasForeignKey("EventTicketAdmissionTypeId")
                   .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<EventTicket>()
                   .HasOne(e => e.EventCustomer)
                   .WithMany()
                   .HasForeignKey("EventCustomerId");
            //builder.Entity<EventTicket>()
            //       .Property(e => e.Enabled)
            //       .HasDefaultValue(true);
            builder.Entity<EventTicket>()
                   .Property(e => e.UniqueIdentifier)
                   .IsRequired(true);

            builder.Entity<EventTicketHistory>()
                   .HasKey(e => e.EventTicketHistoryId);
            builder.Entity<EventTicketHistory>()
                   .Property(e => e.EventTicketId)
                   .IsRequired(true);
            builder.Entity<EventTicketHistory>()
                   .Property(e => e.ApplicationUserId)
                   .IsRequired(true);

            builder.Entity<EventTicketStatus>()
                   .HasKey(e => new { e.EventTicketId, e.EventTicketAdmissionTypeId });
            builder.Entity<EventTicketStatus>()
                   .HasOne(e => e.EventTicket)
                   .WithMany()
                   .HasForeignKey("EventTicketId")
                   .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<EventTicketStatus>()
                   .HasOne(e => e.EventTicketAdmissionType)
                   .WithMany()
                   .HasForeignKey("EventTicketAdmissionTypeId");

            builder.Entity<EventTicketStatusHistory>()
                   .HasKey(e => e.EventTicketStatusHistoryId);
            builder.Entity<EventTicketStatusHistory>()
                   .HasOne(e => e.EventTicket)
                   .WithMany()
                   .HasForeignKey("EventTicketId")
                   .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<EventTicketStatusHistory>()
                   .HasOne(e => e.EventTicketAdmissionType)
                   .WithMany()
                   .HasForeignKey("EventTicketAdmissionTypeId");
            builder.Entity<EventTicketStatusHistory>()
                   .HasOne(e => e.EventStation)
                   .WithMany()
                   .HasForeignKey("EventStationId");
            #endregion

            #region SmartWatch DbContext
            builder.Entity<PourSpout>()
                   .HasKey(p => p.PourSpoutId);

            builder.Entity<SmartWatchSession>()
                   .HasKey(e => e.SmartWatchSessionId);
            builder.Entity<SmartWatchSession>()
                   .Property(i => i.IntervalDuration)
                   .HasColumnType("decimal(5,3)");
            builder.Entity<SmartWatchSession>()
                   .HasOne(e => e.PourSpout)
                   .WithMany()
                   .HasForeignKey("PourSpoutId");

            builder.Entity<SmartWatchSessionData>()
                   .HasKey(e => new { e.Interval, e.SmartWatchSessionId });
            builder.Entity<SmartWatchSessionData>()
                   .HasOne(e => e.SmartWatchSession)
                   .WithMany()
                   .HasForeignKey("SmartWatchSessionId");

            builder.Entity<SmartWatchConfiguration>()
                   .HasKey(e => e.SmartWatchConfigurationId);
            #endregion
        }

        //Inventory
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<StockItem> StockItems { get; set; }
        public DbSet<StockItemTag> StockItemTags { get; set; }
        public DbSet<SerializedStockItem> SerializedStockItems { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Bar> Bars { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<InventoryActionHistory> InventoryActionHistories { get; set; }
        public DbSet<InventoryHistory> InventoryHistories { get; set; }
        public DbSet<DeviceScale> DeviceScales { get; set; }


        //EventManagement
        public DbSet<Event> Events { get; set; }
        public DbSet<EventStation> EventStations { get; set; }
        public DbSet<EventTicketAdmissionType> EventTicketAdmissionTypes { get; set; }
        public DbSet<EventStationAssignment> EventStationAssignments { get; set; }
        public DbSet<EventCustomer> EventCustomers { get; set; }
        public DbSet<EventTicket> EventTickets { get; set; }
        public DbSet<EventTicketHistory> EventTicketHistories { get; set; }
        public DbSet<EventTicketStatus> EventTicketStatuses { get; set; }
        public DbSet<EventTicketStatusHistory> EventTicketStatusHistories { get; set; }

        //SmartWatch
        public DbSet<SmartWatchSession> SmartWatchSessions { get; set; }
        public DbSet<SmartWatchSessionData> SmartWatchSessionData { get; set; }
        public DbSet<PourSpout> PourSpouts { get; set; }
        public DbSet<SmartWatchConfiguration> SmartWatchConfigurations { get; set; }
    }
}
