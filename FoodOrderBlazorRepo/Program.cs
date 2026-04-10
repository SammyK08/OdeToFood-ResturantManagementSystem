using FoodOrderBlazorRepo.Api;
using FoodOrderBlazorRepo.Data;
using FoodOrderBlazorRepo.Dtos;
using FoodOrderBlazorRepo.Models.Entities;
using FoodOrderBlazorRepo.Services;
using Microsoft.EntityFrameworkCore;
using Telerik.Blazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped(sp =>
{
    var accessor = sp.GetRequiredService<IHttpContextAccessor>();
    var request = accessor.HttpContext?.Request;
    var baseUrl = request is null
        ? "https://localhost:5001"
        : $"{request.Scheme}://{request.Host}";

    return new HttpClient { BaseAddress = new Uri(baseUrl) };
});

builder.Services.AddScoped<OrderApiClient>();
builder.Services.AddTelerikBlazor();
builder.Services.AddSingleton<OrderService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapGet("/api/menu", async (AppDbContext db) =>
{
    var items = await db.MenuItems
        .OrderBy(x => x.Id)
        .Select(x => new MenuItemDto(x.Id, x.Name, x.Description, x.Price))
        .ToListAsync();

    return Results.Ok(items);
});

app.MapPost("/api/orders", async (CreateOrderDto payload, AppDbContext db) =>
{
    if (payload.Items.Count == 0)
    {
        return Results.BadRequest("Order must include at least one item.");
    }

    var menuItemIds = payload.Items.Select(x => x.MenuItemId).Distinct().ToList();
    var menuItems = await db.MenuItems.Where(x => menuItemIds.Contains(x.Id)).ToListAsync();

    if (menuItems.Count != menuItemIds.Count)
    {
        return Results.BadRequest("One or more menu items were not found.");
    }

    var orderItems = payload.Items.Select(item =>
    {
        var menuItem = menuItems.First(x => x.Id == item.MenuItemId);
        return new OrderItemEntity
        {
            MenuItemEntityId = menuItem.Id,
            ItemName = menuItem.Name,
            UnitPrice = menuItem.Price,
            Quantity = Math.Max(1, item.Quantity)
        };
    }).ToList();

    var order = new OrderEntity
    {
        CreatedAtUtc = DateTime.UtcNow,
        Items = orderItems,
        Total = orderItems.Sum(x => x.UnitPrice * x.Quantity)
    };

    db.Orders.Add(order);
    await db.SaveChangesAsync();

    return Results.Ok(new OrderResultDto
    {
        OrderId = order.Id,
        Total = order.Total,
        CreatedAtUtc = order.CreatedAtUtc
    });
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
