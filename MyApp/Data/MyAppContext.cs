using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Data;

public class MyAppContext : DbContext
{
    public MyAppContext(DbContextOptions<MyAppContext> options) : base(options) { }

    // TAKES ModelBuilder CLASS, WHEN PERFORMING AN EF UPDATING
    // CREATES A ONE-TO-ONE RELATIONSHIP BETWEEN ITEM.SERIALNUMBERID AND 
    // SERIALNUMBER.ITEMID
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemClient>().HasKey(ic => new
        {
            ic.ItemId,
            ic.ClientId
        });

        modelBuilder.Entity<ItemClient>()
            .HasOne(i => i.Item)
            .WithMany(ic => ic.ItemClients)
            .HasForeignKey(i => i.ItemId);

        modelBuilder.Entity<ItemClient>()
            .HasOne(c => c.Client)
            .WithMany(ic => ic.ItemClients)
            .HasForeignKey(c => c.ClientId);

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

        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "Electronics",
            },
            new Category
            {
                Id = 2,
                Name = "Books",
            }
        );

        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Item> Items { get; set; }

    public DbSet<SerialNumber> SerialNumbers { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Client> Client { get; set; }
    public DbSet<ItemClient> ItemClients { get; set; }
}