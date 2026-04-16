namespace Bookly.Application.Features.Queries.Orders.GetMyOrders;
public class GetMyOrdersQueryResponse
{
    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = string.Empty;
    public List<GetMyOrdersItemDto> Items { get; set; } = new();
}

public class GetMyOrdersItemDto
{
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
