using FoodOrderBlazorRepo.Dtos;
using FoodOrderBlazorRepo.Models;

namespace FoodOrderBlazorRepo.Api;

public class OrderApiClient(HttpClient httpClient)
{
    public async Task<IReadOnlyList<FoodItem>> GetMenuAsync(CancellationToken cancellationToken = default)
    {
        var items = await httpClient.GetFromJsonAsync<List<MenuItemDto>>("api/menu", cancellationToken);
        return items?.Select(x => new FoodItem(x.Id, x.Name, x.Description, x.Price)).ToList() ?? [];
    }

    public async Task<OrderResultDto?> SubmitOrderAsync(IEnumerable<CartItem> cartItems, CancellationToken cancellationToken = default)
    {
        var payload = new CreateOrderDto
        {
            Items = cartItems.Select(x => new CreateOrderItemDto
            {
                MenuItemId = x.FoodItem.Id,
                Quantity = x.Quantity
            }).ToList()
        };

        var response = await httpClient.PostAsJsonAsync("api/orders", payload, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<OrderResultDto>(cancellationToken);
    }
}
