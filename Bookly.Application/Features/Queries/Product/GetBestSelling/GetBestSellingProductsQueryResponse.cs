namespace Bookly.Application.Features.Queries.Product.GetBestSelling;
public class GetBestSellingProductsQueryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public int TotalSold { get; set; }
}
