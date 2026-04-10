using FoodOrderBlazorRepo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderBlazorRepo.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<MenuItemEntity> MenuItems => Set<MenuItemEntity>();
    public DbSet<OrderEntity> Orders => Set<OrderEntity>();
    public DbSet<OrderItemEntity> OrderItems => Set<OrderItemEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderItemEntity>()
            .HasOne(x => x.Order)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.OrderEntityId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<MenuItemEntity>().HasData(
            new MenuItemEntity { Id = 1, Name = "Classic Burger", Description = "Beef patty, cheddar, pickles, house sauce", Price = 11.99m },
            new MenuItemEntity { Id = 2, Name = "Margherita Pizza", Description = "Tomato, mozzarella, basil", Price = 13.49m },
            new MenuItemEntity { Id = 3, Name = "Chicken Caesar Wrap", Description = "Grilled chicken, romaine, parmesan", Price = 9.99m },
            new MenuItemEntity { Id = 4, Name = "Fries", Description = "Crispy skin-on fries", Price = 3.99m }
        );
    }
}
