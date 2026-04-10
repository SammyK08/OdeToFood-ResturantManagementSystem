namespace FoodOrderBlazorRepo.Models;

public class CartItem
{
    public required FoodItem FoodItem { get; init; }
    public int Quantity { get; set; }
    public decimal LineTotal => FoodItem.Price * Quantity;
}
