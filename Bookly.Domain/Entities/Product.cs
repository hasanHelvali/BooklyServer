using Bookly.Domain.Abstractions;

namespace Bookly.Domain.Entities;
public class Product:BaseEntity
{
    public string Name { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public bool IsActive { get; set; }
}
