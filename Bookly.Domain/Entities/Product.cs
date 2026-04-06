using Bookly.Domain.Abstractions;

namespace Bookly.Domain.Entities;
public class Product:BaseEntity
{
    public string Name { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Category { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsActive { get; set; }
}
