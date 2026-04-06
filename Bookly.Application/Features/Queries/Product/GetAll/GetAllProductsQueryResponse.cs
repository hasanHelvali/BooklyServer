namespace Bookly.Application.Features.Queries.Product.GetAll;
public class GetAllProductsQueryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Category { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsActive { get; set; }
}
