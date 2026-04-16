namespace Bookly.Application.Features.Queries.Product.GetById;
public class GetProductByIdQueryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string? ImageUrl { get; set; }
}
