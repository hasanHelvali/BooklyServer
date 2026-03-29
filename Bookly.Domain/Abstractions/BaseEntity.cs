namespace Bookly.Domain.Abstractions;

public abstract class BaseEntity
{
    public Guid  ID{ get; set; }
    public DateTime CreatedAt{ get; set; }
    public DateTime UpdatedAt { get; set; }

    protected BaseEntity()
    {
        ID=Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }
}
