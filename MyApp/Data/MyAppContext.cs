using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Data;

public class MyAppContext : DbContext
{
    public MyAppContext(DbContextOptions<MyAppContext> options) : base(options) {}

    // TAKES ModelBuilder CLASS, WHEN PERFORMING AN EF UPDATING
    // CREATES A ONE-TO-ONE RELATIONSHIP BETWEEN ITEM.SERIALNUMBERID AND 
    // SERIALNUMBER.ITEMID
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().HasData(
            new Item
            {
                Id = 4,
                Name = "Microphone",
                Color = "Silver",
                Price = 84,
                SerialNumberId = 10
            }
        );

        modelBuilder.Entity<SerialNumber>().HasData(
            new SerialNumber
            {
                Id = 10,
                Name = "MIC150",
                ItemId = 4
            }
        );

        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Item> Items { get; set; }

    public DbSet<SerialNumber> SerialNumbers { get; set; }
}