namespace FoodOrderBlazorRepo.Models.Entities;

public class OrderItemEntity
{
    public int Id { get; set; }
    public int OrderEntityId { get; set; }
    public int MenuItemEntityId { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }

    public OrderEntity? Order { get; set; }
}
