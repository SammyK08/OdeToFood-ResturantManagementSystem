# FoodOrderBlazorRepo

A Blazor Web App with Telerik UI for Blazor, .NET backend API, SQL Server database, and Entity Framework Core.

## Features
- Blazor UI built with Telerik components (`TelerikGrid`, `TelerikButton`, `TelerikNotification`).
- Backend REST API:
  - `GET /api/menu`
  - `POST /api/orders`
- SQL Server persistence through EF Core (`AppDbContext`).

## Data Model
- `MenuItemEntity`: menu catalog data.
- `OrderEntity`: order header with total and timestamp.
- `OrderItemEntity`: order line items linked to each order.

## Run locally
1. Install .NET 8 SDK and SQL Server (or LocalDB).
2. Configure Telerik UI for Blazor license according to Telerik docs.
3. Update `ConnectionStrings:DefaultConnection` in `appsettings.json` if needed.
4. From this folder run:
   ```bash
   dotnet restore
   dotnet run
   ```

The app ensures the database is created on startup and seeds a starter menu.
