using Bookly.Domain.Abstractions;

namespace Bookly.Domain.Entities;
public class Category:BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}
