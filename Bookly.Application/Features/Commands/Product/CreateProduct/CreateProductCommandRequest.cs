using MediatR;

namespace Bookly.Application.Features.Commands.Product.CreateProduct;
public class CreateProductCommandRequest:IRequest<CreateProductCommandResponse>
{
    public string Name { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Category { get; set; }
    public string? ImageUrl { get; set; }
}
