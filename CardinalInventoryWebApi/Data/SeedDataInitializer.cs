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
                    var b = new Bar()
                    {
                        BarId = Guid.NewGuid(),
                        Description = "Jack & Ginger's Irish Pub",
                        Active = true
                    };
                    await context.Bars.AddAsync(b);

                    var building = new Building()
                    {
                        BuildingId = Guid.NewGuid(),
                        BarId = b.BarId,
                        Description = "11500B Rock Rose",
                        Active = true
                    };
                    await context.Buidings.AddAsync(building);

                    var outside = new Area()
                    {
                        AreaId = Guid.NewGuid(),
                        BuildingId = building.BuildingId,
                        Description = "Outside Bar",
                        Active = true
                    };
                    await context.Areas.AddAsync(outside);
                }
                if (context.StockItemCategories.Count() == 0)
                {
                    var sic = new StockItemCategory()
                    {
                        StockItemCategoryId = Guid.NewGuid(),
                        Description = "Whiskey"
                    };
                    await context.StockItemCategories.AddAsync(sic);

                    var whiskey01 = new StockItem()
                    {
                        StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Bulleit Bourbon",
                        ImagePath = "bulleit-bourbon-1L.jpeg",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 19.99M
                    };
                    await context.StockItems.AddAsync(whiskey01);

                    var whiskey02 = new StockItem()
                    {
                        StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Fireball Cinnamon Whisky",
                        ImagePath = "fireball-cinnamon-whisky-1L.jpeg",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 11.49M
                    };
                    await context.StockItems.AddAsync(whiskey02);

                    var whiskey03 = new StockItem()
                    {
                        StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Jameson Irish Whiskey",
                        ImagePath = "jameson-irish-whiskey-1L.jpeg",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 16.99M
                    };
                    await context.StockItems.AddAsync(whiskey03);

                    var whiskey04 = new StockItem()
                    {
                        StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Maker's Mark Bourbon Whisky",
                        ImagePath = "makers-mark-bourbon-whisky-1L.jpeg",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 19.98M
                    };
                    await context.StockItems.AddAsync(whiskey04);

                    var whiskey05 = new StockItem()
                    {
                        StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Jack Daniel's Old No. 7 Whiskey",
                        ImagePath = "jack-daniels-old-no-7-1L.jpeg",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 12.99M
                    };
                    await context.StockItems.AddAsync(whiskey05);

                    var whiskey06 = new StockItem()
                    {
                        StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Jim Beam Bourbon Whiskey",
                        ImagePath = "jim-beam-bourbon-whiskey-1L.jpeg",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 9.99M
                    };
                    await context.StockItems.AddAsync(whiskey06);

                    var whiskey07 = new StockItem()
                    {
                        StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Johnnie Walker Black Label",
                        ImagePath = "johnnie-walker-black-label-1L.jpeg",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 24.99M
                    };
                    await context.StockItems.AddAsync(whiskey07);

                    var whiskey08 = new StockItem()
                    {
                        StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Evan Williams Bourbon Whiskey Black Label",
                        ImagePath = "evan-williams-black-1L.jpeg",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 8.79M
                    };
                    await context.StockItems.AddAsync(whiskey08);

                    var whiskey09 = new StockItem()
                    {
                        StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Bulleit Rye",
                        ImagePath = "bulleit-rye-1L.jpeg",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 19.99M
                    };
                    await context.StockItems.AddAsync(whiskey09);

                    var whiskey10 = new StockItem()
                    {
                        StockItemCategoryId = sic.StockItemCategoryId,
                        StockItemId = Guid.NewGuid(),
                        Description = "Crown Royal Deluxe",
                        ImagePath = "crown-royal-deluxe-1L.jpeg",
                        UnitSizeMilliliters = 1000,
                        UnitCost = 9.99M
                    };
                    await context.StockItems.AddAsync(whiskey10);
                }
                await context.SaveChangesAsync();
            }
        }
    }
}
