namespace FoodOrderBlazorRepo.Dtos;

public class CreateOrderDto
{
    public List<CreateOrderItemDto> Items { get; init; } = [];
}

public class CreateOrderItemDto
{
    public int MenuItemId { get; init; }
    public int Quantity { get; init; }
}
