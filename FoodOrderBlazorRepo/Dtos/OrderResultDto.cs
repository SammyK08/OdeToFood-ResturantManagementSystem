namespace FoodOrderBlazorRepo.Dtos;

public class OrderResultDto
{
    public int OrderId { get; init; }
    public decimal Total { get; init; }
    public DateTime CreatedAtUtc { get; init; }
}
