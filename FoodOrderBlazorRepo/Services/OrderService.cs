using FoodOrderBlazorRepo.Models;

namespace FoodOrderBlazorRepo.Services;

public class OrderService
{
    private readonly List<CartItem> _cartItems = [];

    public IReadOnlyList<CartItem> CartItems => _cartItems;
    public decimal Total => _cartItems.Sum(i => i.LineTotal);

    public void AddItem(FoodItem item)
    {
        var existing = _cartItems.FirstOrDefault(x => x.FoodItem.Id == item.Id);
        if (existing is null)
        {
            _cartItems.Add(new CartItem { FoodItem = item, Quantity = 1 });
            return;
        }

        existing.Quantity++;
    }

    public void ClearCart()
    {
        _cartItems.Clear();
    }
}
