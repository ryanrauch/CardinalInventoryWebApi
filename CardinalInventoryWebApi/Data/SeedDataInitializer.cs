using CardinalInventoryWebApi.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardinalInventoryWebApi.Data
{
    public class SeedDataInitializer
    {

        public static async Task SeedData(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if(context.Bars.Count() == 0)
                {
                    var company = new Company()
                    {
                        CompanyId = Guid.NewGuid(),
                        Description = "Union Venture Group",
                        Active = true
                    };
                    await context.Companies.AddAsync(company);
                    await context.SaveChangesAsync();

                    var b = new Bar()
                    {
                        BarId = Guid.NewGuid(),
                        CompanyId = company.CompanyId,
                        Description = "Jack & Ginger's Irish Pub",
                        Active = true
                    };
                    await context.Bars.AddAsync(b);
                    await context.SaveChangesAsync();

                    var building = new Building()
                    {
                        BuildingId = Guid.NewGuid(),
                        BarId = b.BarId,
                        Description = "11500B Rock Rose",
                        Active = true
                    };
                    await context.Buildings.AddAsync(building);
                    await context.SaveChangesAsync();

                    var floor = new Floor()
                    {
                        FloorId = Guid.NewGuid(),
                        Description = "Ground-Level",
                        BuildingId = building.BuildingId,
                        Active = true
                    };
                    await context.Floors.AddAsync(floor);
                    await context.SaveChangesAsync();

                    var outside = new Area()
                    {
                        AreaId = Guid.NewGuid(),
                        FloorId = floor.FloorId,
                        Description = "Outside Bar",
                        Active = true
                    };
                    await context.Areas.AddAsync(outside);
                    await context.SaveChangesAsync();
                }
                if (context.StockItems.Count() == 0)
                {
                    var titos = new StockItem()
                    {
                        StockItemId = Guid.NewGuid(),
                        Description = "Tito's Handmade Vodka 1L",
                        Barcode = "1994700001",
                        UnitSizeMilliliters=1000
                    };
                    await context.StockItems.AddAsync(titos);
                    await context.SaveChangesAsync();

                    var stitos = new SerializedStockItem()
                    {
                        SerializedStockItemId = Guid.NewGuid(),
                        StockItemId = titos.StockItemId,
                        Barcode = "01209920",
                        CurrentItemLevel = 1.0M,
                        ReceivedDate = DateTime.Now,
                        LastModifiedDate = DateTime.Now
                    };
                    await context.SerializedStockItems.AddAsync(stitos);
                    await context.SaveChangesAsync();
                }

                /*if (context.StockItems.Count() == 0)
                {
                    //var sic = new StockItemCategory()
                    //{
                    //    StockItemCategoryId = Guid.NewGuid(),
                    //    Description = "Whiskey"
                    //};
                    //await context.StockItemCategories.AddAsync(sic);

                    var whiskey01 = new StockItem()
                    {
                        //StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Bulleit Bourbon",
                        ImagePath = "bulleit-bourbon-1L.png",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 19.99M
                    };
                    await context.StockItems.AddAsync(whiskey01);

                    var whiskey02 = new StockItem()
                    {
                        //StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Fireball Cinnamon Whisky",
                        ImagePath = "fireball-cinnamon-whisky-1L.png",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 11.49M
                    };
                    await context.StockItems.AddAsync(whiskey02);

                    var whiskey03 = new StockItem()
                    {
                        //StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Jameson Irish Whiskey",
                        ImagePath = "jameson-irish-whiskey-1L.png",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 16.99M
                    };
                    await context.StockItems.AddAsync(whiskey03);

                    var whiskey04 = new StockItem()
                    {
                        //StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Maker's Mark Bourbon Whisky",
                        ImagePath = "makers-mark-bourbon-whisky-1L.png",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 19.98M
                    };
                    await context.StockItems.AddAsync(whiskey04);

                    var whiskey05 = new StockItem()
                    {
                        //StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Jack Daniel's Old No. 7 Whiskey",
                        ImagePath = "jack-daniels-old-no-7-1L.png",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 12.99M
                    };
                    await context.StockItems.AddAsync(whiskey05);

                    var whiskey06 = new StockItem()
                    {
                        //StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Jim Beam Bourbon Whiskey",
                        ImagePath = "jim-beam-bourbon-whiskey-1L.png",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 9.99M
                    };
                    await context.StockItems.AddAsync(whiskey06);

                    var whiskey07 = new StockItem()
                    {
                        //StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Johnnie Walker Black Label",
                        ImagePath = "johnnie-walker-black-label-1L.png",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 24.99M
                    };
                    await context.StockItems.AddAsync(whiskey07);

                    var whiskey08 = new StockItem()
                    {
                        //StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Evan Williams Bourbon Whiskey Black Label",
                        ImagePath = "evan-williams-black-1L.png",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 8.79M
                    };
                    await context.StockItems.AddAsync(whiskey08);

                    var whiskey09 = new StockItem()
                    {
                        //StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Bulleit Rye",
                        ImagePath = "bulleit-rye-1L.png",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 19.99M
                    };
                    await context.StockItems.AddAsync(whiskey09);

                    var whiskey10 = new StockItem()
                    {
                        //StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Crown Royal Deluxe",
                        ImagePath = "crown-royal-deluxe-1L.png",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 9.99M
                    };
                    await context.StockItems.AddAsync(whiskey10);

                    var whiskey11 = new StockItem()
                    {
                        //StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Buffalo Trace Bourbon",
                        ImagePath = "buffalo-trace-bourbon-1L.png",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 9.99M
                    };
                    await context.StockItems.AddAsync(whiskey11);

                    var whiskey12 = new StockItem()
                    {
                        //StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Knob Creek Kentucky Straight Bourbon Whiskey",
                        ImagePath = "knob-creek-kentucky-straight-bourbon-whiskey-1L.png",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 22.80M
                    };
                    await context.StockItems.AddAsync(whiskey12);

                    var whiskey13 = new StockItem()
                    {
                        //StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Woodford Reserve Bourbon",
                        ImagePath = "woodford-reserve-bourbon-1L.png",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 22.99M
                    };
                    await context.StockItems.AddAsync(whiskey13);

                    var whiskey14 = new StockItem()
                    {
                        //StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Basil Hayden's Kentucky Straight Bourbon Whiskey",
                        ImagePath = "basil-haydens-kentucky-straight-bourbon-whiskey-1L.png",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 22.99M
                    };
                    await context.StockItems.AddAsync(whiskey14);

                    var whiskey15 = new StockItem()
                    {
                        //StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "The Macallan 12 Year Sherry Oak",
                        ImagePath = "the-macallan-sherry-oak-12-year-1L.png",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 47.25M
                    };
                    await context.StockItems.AddAsync(whiskey15);

                    var whiskey16 = new StockItem()
                    {
                        //StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Seagram's 7 Crown Blended Whiskey",
                        ImagePath = "seagrams-7-crown-1L.png",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 8.99M
                    };
                    await context.StockItems.AddAsync(whiskey16);

                    var whiskey17 = new StockItem()
                    {
                        //StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Four Roses Bourbon",
                        ImagePath = "four-roses-bourbon-1L.png",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 13.99M
                    };
                    await context.StockItems.AddAsync(whiskey17);

                    var whiskey18 = new StockItem()
                    {
                        //StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Jack Daniel's Tennessee Honey",
                        ImagePath = "jack-daniels-tennessee-honey-1L.png",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 16.99M
                    };
                    await context.StockItems.AddAsync(whiskey18);

                    var whiskey19 = new StockItem()
                    {
                        //StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Dewar's White Label",
                        ImagePath = "dewars-white-label-1L.png",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 17.99M
                    };
                    await context.StockItems.AddAsync(whiskey19);

                    var whiskey20 = new StockItem()
                    {
                        //StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Hibiki Japanese Harmony Whisky",
                        ImagePath = "hibiki-japanese-harmony-whisky-1L.png",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 57.10M
                    };
                    await context.StockItems.AddAsync(whiskey20);

                    var whiskey21 = new StockItem()
                    {
                        //StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Old Overholt Rye Whiskey",
                        ImagePath = "old-overholt-original-1L.png",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 12.49M
                    };
                    await context.StockItems.AddAsync(whiskey21);

                    var whiskey22 = new StockItem()
                    {
                        //StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Johnnie Walker Red Label",
                        ImagePath = "johnnie-walker-red-label-1L.png",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 14.99M
                    };
                    await context.StockItems.AddAsync(whiskey22);

                    var whiskey23 = new StockItem()
                    {
                        //StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Lagavulin 16 Year",
                        ImagePath = "lagavulin-16-year-1L.png",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 61.52M
                    };
                    await context.StockItems.AddAsync(whiskey23);

                    var whiskey24 = new StockItem()
                    {
                        //StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Crown Royal Apple",
                        ImagePath = "crown-royal-regal-apple-1L.png",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 18.99M
                    };
                    await context.StockItems.AddAsync(whiskey24);
                }
                */
                await context.SaveChangesAsync();
            }
        }
    }
}
