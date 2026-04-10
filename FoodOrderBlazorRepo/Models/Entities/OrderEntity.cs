namespace FoodOrderBlazorRepo.Models.Entities;

public class OrderEntity
{
    public int Id { get; set; }
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public decimal Total { get; set; }
    public List<OrderItemEntity> Items { get; set; } = [];
}
